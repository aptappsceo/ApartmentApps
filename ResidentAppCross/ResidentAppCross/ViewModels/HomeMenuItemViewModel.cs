using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.ViewModels;
using static ResidentAppCross.Resources.SharedResources;

namespace ResidentAppCross
{
    public class HomeMenuItemViewModel : MvxViewModel
    {
        public string Name { get; set; }
        public Icons Icon { get; set; }
        public ICommand Command { get; set; }
        public BadgeType BadgeType { get; set; }
        public string BadgeLabel { get; set; }

        public bool ShowBadge => !string.IsNullOrEmpty(BadgeLabel);
    }
}
