using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.ViewModels;
using static ResidentAppCross.Resources.SharedResources;

namespace ResidentAppCross
{
    public class HomeMenuItemViewModel : MvxViewModel
    {
        public string Name { get; set; }
        public Icons Icon { get; set; }
        public MvxCommand Command { get; set; }
        public BadgeType BadgeType { get; set; }
        public string BandgeLabel { get; set; }
    }
}
