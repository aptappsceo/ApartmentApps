using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResidentAppCross.Resources;

namespace ResidentAppCross.Services
{
    public interface IDialogService
    {
		Task<T> OpenSearchableTableSelectionDialog<T>(IList<T> items, string title, Func<T,string> itemTitleSelector, Func<T, string> itemSubtitleSelector = null, object arg = null);
        Task<DateTime?> OpenDateTimeDialog(string title);
        Task<DateTime?> OpenDateDialog(string title);
        Task<byte[]> OpenImageDialog();
        void OpenNotification(string title, string subtitle, string ok, Action action = null);
        void OpenImageFullScreen(object imageObject);
        void OpenImageFullScreenFromUrl(string url);

        void OpenUrl(string url);
    }
}
