using System;
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
            if (type.FullName.Contains("DynamicProx"))
            {
                type = type.BaseType;
            }
            var properties =
                type.GetProperties(BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic |
                                   BindingFlags.Instance).ToList();

            foreach (var property in properties)
            {
                if (property.Name.EndsWith("_Items")) continue;

                var propertyModel = new FormPropertyModel();
                propertyModel.DataType = property.GetCustomAttributes(typeof(DataTypeAttribute), true).OfType<DataTypeAttribute>().FirstOrDefault();
                if (propertyModel.DataType?.CustomDataType == "Ignore") continue;

                if (propertyModel.DataType != null)
                    propertyModel.Hidden = propertyModel.DataType.CustomDataType == "Hidden";
              
                propertyModel.SystemType = property.PropertyType;
                propertyModel.Name = property.Name;
                propertyModel.GetValue = () => property.GetValue(model);
                propertyModel.SetValue = (v) => property.SetValue(model,v);
                propertyModel.Description = property.GetCustomAttributes(typeof(DescriptionAttribute), true).OfType<DescriptionAttribute>().FirstOrDefault()?.Description;
                propertyModel.Label = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? property.Name;
               
              
                if (typeof (Enum).IsAssignableFrom(property.PropertyType))
                {
                    var names = Enum.GetNames(property.PropertyType);
                    propertyModel.Choices =
                        names.Select(p => new FormPropertySelectItem(p, p, p == property.GetValue(model).ToString()) {}).ToArray();
                }
                else
                {
                    propertyModel.Choices =
                        ((IEnumerable<FormPropertySelectItem>)properties.FirstOrDefault(p => p.Name == property.Name + "_Items")?.GetValue(model))?.ToArray();
                }
                

                formModel.Properties.Add(propertyModel);
            }

            return formModel;
        }

        public GridModel CreateGridFor(Type type, object[] items )
        {
          
            var formModel = new GridModel();
            var properties =
                type.GetProperties(BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic |
                                   BindingFlags.Instance).ToList();

            foreach (var property in properties)
            {
                if (property.Name.EndsWith("_Items")) continue;
                var propertyModel = new FormPropertyModel();
                propertyModel.SystemType = property.PropertyType;
                propertyModel.Name = property.Name;
               
                propertyModel.Description = property.GetCustomAttributes(typeof(DescriptionAttribute), true).OfType<DescriptionAttribute>().FirstOrDefault()?.Description;
                propertyModel.Label = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? property.Name;
                propertyModel.DataType = property.GetCustomAttributes(typeof(DataTypeAttribute), true).OfType<DataTypeAttribute>().FirstOrDefault();
                propertyModel.Hidden = propertyModel.DataType.CustomDataType == "Hidden";
      

                formModel.Properties.Add(propertyModel);
            }

            return formModel;
        }

    }
}