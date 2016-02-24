using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAppCross.ViewModels.Data
{
    public class ChangeViewModel<T>
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
