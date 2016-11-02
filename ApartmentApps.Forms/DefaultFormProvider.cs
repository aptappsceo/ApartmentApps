using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ApartmentApps.Forms
{
    public static class SortExtensions
    {
        public static IEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            int max = source
                .SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?) m.Value.Length))
                .Max() ?? 0;

            return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
        }
    }

    public class AlphanumComparatorFast : IComparer
    {
        List<string> GetList(string s1)
        {
            List<string> SB1 = new List<string>();
            string st1, st2, st3;
            st1 = "";
            bool flag = char.IsDigit(s1[0]);
            foreach (char c in s1)
            {
                if (flag != char.IsDigit(c) || c == '\'')
                {
                    if (st1 != "")
                        SB1.Add(st1);
                    st1 = "";
                    flag = char.IsDigit(c);
                }
                if (char.IsDigit(c))
                {
                    st1 += c;
                }
                if (char.IsLetter(c))
                {
                    st1 += c;
                }
            }
            SB1.Add(st1);
            return SB1;
        }

        public int Compare(object x, object y)
        {
            string s1 = x as string;
            if (s1 == null)
            {
                return 0;
            }
            string s2 = y as string;
            if (s2 == null)
            {
                return 0;
            }
            if (s1 == s2)
            {
                return 0;
            }
            int len1 = s1.Length;
            int len2 = s2.Length;
            int marker1 = 0;
            int marker2 = 0;

            // Walk through two the strings with two markers.
            List<string> str1 = GetList(s1);
            List<string> str2 = GetList(s2);
            while (str1.Count != str2.Count)
            {
                if (str1.Count < str2.Count)
                {
                    str1.Add("");
                }
                else
                {
                    str2.Add("");
                }
            }
            int x1 = 0;
            int res = 0;
            int x2 = 0;
            string y2 = "";
            bool status = false;
            string y1 = "";
            bool s1Status = false;
            bool s2Status = false;
            //s1status ==false then string ele int;
            //s2status ==false then string ele int;
            int result = 0;
            for (int i = 0; i < str1.Count && i < str2.Count; i++)
            {
                status = int.TryParse(str1[i].ToString(), out res);
                if (res == 0)
                {
                    y1 = str1[i].ToString();
                    s1Status = false;
                }
                else
                {
                    x1 = Convert.ToInt32(str1[i].ToString());
                    s1Status = true;
                }

                status = int.TryParse(str2[i].ToString(), out res);
                if (res == 0)
                {
                    y2 = str2[i].ToString();
                    s2Status = false;
                }
                else
                {
                    x2 = Convert.ToInt32(str2[i].ToString());
                    s2Status = true;
                }
                //checking --the data comparision
                if (!s2Status && !s1Status) //both are strings
                {
                    result = str1[i].CompareTo(str2[i]);
                }
                else if (s2Status && s1Status) //both are intergers
                {
                    if (x1 == x2)
                    {
                        if (str1[i].ToString().Length < str2[i].ToString().Length)
                        {
                            result = 1;
                        }
                        else if (str1[i].ToString().Length > str2[i].ToString().Length)
                            result = -1;
                        else
                            result = 0;
                    }
                    else
                    {
                        int st1ZeroCount = str1[i].ToString().Trim().Length -
                                           str1[i].ToString().TrimStart(new char[] {'0'}).Length;
                        int st2ZeroCount = str2[i].ToString().Trim().Length -
                                           str2[i].ToString().TrimStart(new char[] {'0'}).Length;
                        if (st1ZeroCount > st2ZeroCount)
                            result = -1;
                        else if (st1ZeroCount < st2ZeroCount)
                            result = 1;
                        else
                            result = x1.CompareTo(x2);
                    }
                }
                else
                {
                    result = str1[i].CompareTo(str2[i]);
                }
                if (result == 0)
                {
                    continue;
                }
                else
                    break;
            }
            return result;
        }
    }

    public class DefaultFormProvider : IFormProvider
    {

        public object GetPropValue(object src, string propName)
        {
             return src?.GetType()?.GetProperty(propName)?.GetValue(src, null);
        }

        public T GetPropValue<T>(object src, string propName)
        {
            var val = GetPropValue(src, propName);
            return (T)val;
        }

        public IEnumerable<FormPropertySelectItem> CreateChoices(object target, string property, string mapId, string mapTitle, object selected = null)
        {
            var list = GetPropValue<IEnumerable<object>>(target, property)?.ToArray();
            if (list == null || !list.Any()) yield break;
            bool many = selected is IList;
            var computeSelected = selected != null;
            var asList = selected as IList;
            var idProperty = list[0].GetType().GetProperty(mapId);
            var titleRetriever = list[0].GetType().GetProperty(mapTitle);
            var selectedId = many ? null : selected;
            var selectedIdString = selected?.ToString();

            foreach (var obj in list)
            {
                var isselected = false;
                var idValue = idProperty?.GetValue(obj,null);
                var idString = idValue?.ToString() ?? obj.ToString();
                var title = titleRetriever?.GetValue(obj,null)?.ToString() ?? obj.ToString();
                if (computeSelected)
                {
                    if (!many)
                    {
                        if (idString == selectedIdString) isselected = true;
                    }
                    else
                    {
                        if (asList.Contains(idValue)) isselected = true;
                    }
                }
                yield return new FormPropertySelectItem(idString,title,isselected);
            }
        }

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

                propertyModel.DataType = property.Get<DataTypeAttribute>();
                if (propertyModel.DataType?.CustomDataType == "Ignore") continue;
                if (propertyModel.DataType != null) propertyModel.Hidden = propertyModel.DataType.CustomDataType == "Hidden";

                propertyModel.SystemType = property.PropertyType;
                propertyModel.Name = property.Name;
                propertyModel.GetValue = () => property.GetValue(model);
                propertyModel.SetValue = (v) => property.SetValue(model, v);
                propertyModel.Description = property.Get<DescriptionAttribute>()?.Description;
                propertyModel.Label = property.Get<DisplayNameAttribute>()?.DisplayName ?? property.Name;

                propertyModel.PropertyInfo = property;

                if (typeof (Enum).IsAssignableFrom(property.PropertyType))
                {
                    var names = Enum.GetNames(property.PropertyType);
                    propertyModel.Choices =
                        names.Select(p => new FormPropertySelectItem(p, p, p == property.GetValue(model).ToString()) {})
                            .ToArray();
                }
                else if(propertyModel.DataType is SelectFromAttribute)
                {
                    var data = propertyModel.DataType as SelectFromAttribute;
                    propertyModel.Choices = CreateChoices(model,data.PropertyName,data.MapId,data.MapTitle,propertyModel.GetValue()).ToArray();
                }
                else
                {
                    propertyModel.Choices =
                        ((IEnumerable<FormPropertySelectItem>)
                            properties.FirstOrDefault(p => p.Name == property.Name + "_Items")?
                            .GetValue(model))?
                            .ToArray();
                }

                if (ModelState != null && ModelState.ContainsKey(propertyModel.Name))
                {
                    propertyModel.Errors = ModelState[propertyModel.Name]
                        .Errors
                        .Select(s => s.ErrorMessage)
                        .ToList();
                }

                propertyModel.Placeholder = property.Get<PlaceholderAttribute>()?.Text;
                propertyModel.Category = property.Get<WithCategory>()?.Text;
                propertyModel.ToggleCategory = property.Get<ToggleCategory>()?.Text;


                formModel.Properties.Add(propertyModel);
            }

            return formModel;
        }

        public GridModel<TItem> CreateGridFor<TItem>()
        {
            var model = new GridModel<TItem>();
            CreateGridFor(model, typeof (TItem));
            return model;
        }

        public GridModel CreateGridFor(Type type)
        {
            return CreateGridFor(new GridModel(), type);
        }

        public GridModel CreateGridFor(GridModel formModel, Type type)
        {
            var properties =
                type.GetProperties(BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic |
                                   BindingFlags.Instance).ToList();

            foreach (var property in properties)
            {
                if (property.Name.EndsWith("_Items") || property.Name == "ActionLinks") continue;
                if (property.PropertyType == typeof (ActionLinkModel))
                {
                    formModel.ActionLinks.Add(property);
                    continue;
                }
                var propertyModel = new FormPropertyModel();

                propertyModel.SystemType = property.PropertyType;
                propertyModel.Name = property.Name;

                propertyModel.Description =
                    property.GetCustomAttributes(typeof (DescriptionAttribute), true)
                        .OfType<DescriptionAttribute>()
                        .FirstOrDefault()?
                        .Description;
                propertyModel.Label =
                    property.GetCustomAttributes(typeof (DisplayNameAttribute), true)
                        .OfType<DisplayNameAttribute>()
                        .FirstOrDefault()?
                        .DisplayName ?? property.Name;
                propertyModel.DataType =
                    property.GetCustomAttributes(typeof (DataTypeAttribute), true)
                        .OfType<DataTypeAttribute>()
                        .FirstOrDefault();
                propertyModel.Hidden = propertyModel.DataType.CustomDataType == "Hidden";
                propertyModel.PropertyInfo = property;

                formModel.Properties.Add(propertyModel);
            }

            return formModel;
        }

        public ModelStateDictionary ModelState { get; set; }



    }

    public class SelectFromAttribute : DataTypeAttribute
    {
        public SelectFromAttribute(string property, string mapId = "Id", string mapTitle = "Title") : base("SelectFrom")
        {
            this.PropertyName = property;
            this.MapId = mapId;
            this.MapTitle = mapTitle;
        }

        public string MapTitle { get; set; }
        public string MapId { get; set; }
        public string PropertyName { get; set; }
    }

    public class PlaceholderAttribute : Attribute
    {
        public string Text { get; set; }

        public PlaceholderAttribute(string text)
        {
            Text = text;
        }
    }

    public class WithCategory : Attribute
    {
        public string Text { get; set; }

        public WithCategory(string text)
        {
            Text = text;
        }
    }

    public class ToggleCategory : Attribute
    {
        public string Text { get; set; }

        public ToggleCategory(string text)
        {
            Text = text;
        }
    }

    public class AutoformHiddenAttribute : DataTypeAttribute
    {
        public AutoformHiddenAttribute() : base("Hidden")
        {
        }
    }

    public class AutoformIgnoreAttribute : DataTypeAttribute
    {
        public AutoformIgnoreAttribute() : base("Ignore")
        {
        }
    }

    public static class PropertyInfoExtensions
    {
        public static TA Get<TA>(this PropertyInfo info)
        {
            return info.GetCustomAttributes(typeof (TA), true)
                .OfType<TA>()
                .FirstOrDefault();
        }
    }

}

 