using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAppCross.Services
{
    public interface IDialogService
    {
        Task<T> OpenSearchableTableSelectionDialog<T>(IList<T> items, string title, Func<T,string> itemTitleSelector, Func<T, string> itemSubtitleSelector = null);
        Task<DateTime?> OpenDateTimeDialog(string title);
        Task<DateTime?> OpenDateDialog(string title);
        Task<byte[]> OpenImageDialog();
    }
}
