using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentAppCross.iOS.Views.TableSources
{
    public class TestDataItem
    {
        public virtual string Icon => "OfficerIcon";
        public virtual string Title { get; set; }
        public bool Moveable { get; set; }
        public bool Editable { get; set; }
        public bool Focusable { get; set; } = true;
    }
}
