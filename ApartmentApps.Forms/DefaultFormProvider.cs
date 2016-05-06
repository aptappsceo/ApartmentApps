using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ApartmentApps.Forms
{
    public class DefaultFormProvider : IFormProvider
    {
        public FormModel CreateFormFor(object model)
        {
            var type = model.GetType();
            var formModel = new FormModel();
            var properties =
                type.GetProperties(BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic |
                                   BindingFlags.Instance).ToList();

            foreach (var property in properties)
            {
                if (property.Name.EndsWith("_Items")) continue;
                var propertyModel = new FormPropertyModel();
                propertyModel.SystemType = property.PropertyType;
                propertyModel.Name = property.Name;
                propertyModel.GetValue = () => property.GetValue(model);
                propertyModel.SetValue = (v) => property.SetValue(model,v);
                propertyModel.Description = property.GetCustomAttributes(typeof(DescriptionAttribute), true).OfType<DescriptionAttribute>().FirstOrDefault()?.Description;
                propertyModel.Label = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? property.Name;
                propertyModel.DataType = property.GetCustomAttributes(typeof(DataTypeAttribute), true).OfType<DataTypeAttribute>().FirstOrDefault();
                propertyModel.Choices =
                    ((IEnumerable<FormPropertySelectItem>)properties.FirstOrDefault(p => p.Name == property.Name + "_Items")?.GetValue(model))?.ToArray();

                formModel.Properties.Add(propertyModel);
            }

            return formModel;
        }

        
    }
}