using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace ResidentAppCross.Events
{
    public class TaskStarted : MvxMessage
    {
        public string Label { get; set; }

        public TaskStarted(object sender) : base(sender)
        {
        }
    }

    public class TaskProgress : MvxMessage
    {
        public string Label { get; set; }
        public int Progress { get; set; }

        public TaskProgress(object sender) : base(sender)
        {
        }
    }

    public class TaskComplete : MvxMessage
    {
        public string Label { get; set; }
        public bool ShouldPrompt { get; set; }
        public Action OnPrompted { get; set; }

        public TaskComplete(object sender) : base(sender)
        {
        }
    }

    public class TaskFailed : MvxMessage
    {
        private string _label;

        public string Label
        {
            get { return _label ?? (Reason?.Message); }
            set { _label = value; }
        }

        public bool ShouldPrompt { get; set; }
        public Exception Reason { get; set; }
        public Action<Exception> OnPrompted { get; set; }
        public bool Processed { get; set; }
        public TaskFailed(object sender) : base(sender)
        {
        }
    }

    public class TaskProgressUpdated : MvxMessage
    {
        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public bool ShouldPrompt { get; set; }

        public TaskProgressUpdated(object sender) : base(sender)
        {
        }
    }
}
