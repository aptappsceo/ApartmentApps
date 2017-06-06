using System;
using System.Collections.Generic;
using System.Linq;

namespace ApartmentApps.Api.Modules
{
    public class DashboardPieViewModel : ComponentViewModel
    {
        private Type _dataType;
        public ChartData[] Data { get; set; }

        public class ChartData
        {
            public string label { get; set; }
            public int data { get; set; }
        }
        public string Subtitle { get; set; }

        public Type DataType
        {
            get
            {
                if (_dataType == null)
                {
                    var firstItem = ListData.FirstOrDefault();
                    if (firstItem != null) return firstItem.GetType();
                }
                return _dataType;
            }
            set { _dataType = value; }
        }

        public IEnumerable<object> ListData { get; set; }

        public DashboardPieViewModel(string title, string subTitle, decimal row, params ChartData[] chartData)
        {
            Data = chartData;
            Stretch = "col-md-12";
            Title = title;
            Subtitle = subTitle;
            Row = row;
        }
    }
}