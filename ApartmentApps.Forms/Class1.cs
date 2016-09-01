using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Forms
{

    public class GridModel
    {
        public List<FormPropertyModel> Properties { get; set; } = new List<FormPropertyModel>();

        public object[] Items { get; set; }

        public bool Editable { get; set; } = true;
        public bool Deletable { get; set; } = true;


    }
    public class FormModel
    {
        public List<FormPropertyModel> Properties { get; set; } = new List<FormPropertyModel>();
    }

    public class FormPropertyModel
    {
        private DataTypeAttribute _dataType;

        public PropertyInfo PropertyInfo { get; set; }
        public string Name { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public FormPropertySelectItem[] Choices { get; set; }

        public bool Required { get; set; }

        public Type SystemType { get; set; }

        public bool Visible
        {
            get
            {
                return true;
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

