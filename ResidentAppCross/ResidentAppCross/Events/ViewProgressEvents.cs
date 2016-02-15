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
        public string Label { get; set; }
        public bool ShouldPrompt { get; set; }
        public Action OnPrompted { get; set; }

        public TaskFailed(object sender) : base(sender)
        {
        }
    }
}
