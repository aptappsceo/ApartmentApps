using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Korzh.EasyQuery.Services;
using Newtonsoft.Json;

namespace ApartmentApps.Forms
{
    public class ActionLinkModel
    {
        public string Label { get; set; }
        public bool IsDialog { get; set; }

        public ActionLinkModel(string label, string action, string controller, object parameters)
        {
            Label = label;
            Action = action;
            Controller = controller;
            Parameters = parameters;
        }

        public ActionLinkModel(string label, string action, string controller)
        {
            Label = label;
            Action = action;
            Controller = controller;
        }

        public ActionLinkModel(string label, string action)
        {
            Label = label;
            Action = action;
        }

        public ActionLinkModel()
        {
        }

        public string Group { get; set; }
        public string GroupName { get; set; }


        public string Action { get; set; }
        public string Controller { get; set; }
        public object Parameters { get; set; }
        public bool Allowed { get; set; }
        public int Index { get; set; }
        public string Icon { get; set; }
    }

    public class GridList<T> : IPagedList<T>, IPaging, IEnumerable<T>, IEnumerable
    {
        public GridList(IEnumerable<T> innerList, long pageIndex, long pageSize, long totalRecords)
        {
            InnerList = innerList.ToList();
            PageIndex = pageIndex;
            PageSize = pageSize;
   
            TotalRecords = totalRecords;
        }
        public int Pages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public List<T> InnerList { get; set; }



        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public long PageIndex { get; set; }
        public long PageSize { get; set; }
        public long PageCount => Pages;
        public long TotalRecords { get; set; }
    }

    public class GridModel<TItem> : GridModel
    {
        public virtual IPagedList<TItem> Items { get; set; }
        public override IEnumerable<object> ObjectItems => Items.Cast<object>();
    }
    public class GridModel
    {
        public string Title { get; set; }
        public List<PropertyInfo> ActionLinks { get; set; } = new List<PropertyInfo>();
        public List<FormPropertyModel> Properties { get; set; } = new List<FormPropertyModel>();

        public virtual IEnumerable<object> ObjectItems { get; set; }

        public bool Editable { get; set; } = true;
        public bool Deletable { get; set; } = true;
        public int Count { get; set; }
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public string OrderBy { get; set; }
        public bool Descending { get; set; }
    }
    public class FormModel
    {
        public List<FormPropertyModel> Properties { get; set; } = new List<FormPropertyModel>();
    }

    public class FormPropertyModel
    {
        private DataTypeAttribute _dataType;
        [JsonIgnore]
        public PropertyInfo PropertyInfo { get; set; }
        public string Name { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public FormPropertySelectItem[] Choices { get; set; }

        public bool Required { get; set; }
        [JsonIgnore]
        public Type SystemType { get; set; }

        public bool IsList => typeof (IList).IsAssignableFrom(SystemType);

        public bool HasChoices => Choices?.Any() ?? false;

        public bool Visible
        {
            get
            {
                return PropertyInfo != null && PropertyInfo.CanWrite || PropertyInfo == null;
            }
        }

        public string VisibleWhen { get; set; }

        public DataTypeAttribute DataType
        {
            get { return _dataType ?? (_dataType = new DataTypeAttribute(System.ComponentModel.DataAnnotations.DataType.Text)); }
            set { _dataType = value; }
        }

        public Func<object> GetValue { get; set; }
        public Action<object> SetValue { get; set; }
        public bool Hidden { get; set; }
        public List<string> Errors { get; set; }
        public bool HasErrors => Errors?.Any() ?? false;
        public string Placeholder { get; set; }
        public string Category { get; set; }
        public string ToggleCategory { get; set; }
        public string[] Roles { get; set; }
    }

    public class FormPropertySelectItem
    {
        public FormPropertySelectItem(string id, string name, bool b)
        {
            Id = id;
            Value = name;
            Selected = b;
        }

        public string Id { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }
    
}

