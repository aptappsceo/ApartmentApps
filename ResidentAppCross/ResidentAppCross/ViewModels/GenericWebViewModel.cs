using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace ResidentAppCross.ViewModels
{
    public class GenericWebViewModel : MvxViewModel
    {
        private string _htmlContent;
        private string _url;

        public void Init(string url, string htmlContent)
        {
            Url = url;
            HtmlContent = htmlContent;
        }

        public string HtmlContent
        {
            get { return _htmlContent; }
            set { SetProperty(ref _htmlContent, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
    }
}
