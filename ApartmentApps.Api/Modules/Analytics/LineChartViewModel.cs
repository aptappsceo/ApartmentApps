using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public class LineChartViewModel : ComponentViewModel
    {
        public string Subtitle { get; set; }

        public string[] labels { get; set; }
        public List<LineChartDataSet> datasets { get; set; } = new List<LineChartDataSet>();

        public class LineChartDataSet
        {
            public string label { get; set; }
            
            public List<int[]> data { get; set; } = new List<int[]>() { };
        }

    }
}