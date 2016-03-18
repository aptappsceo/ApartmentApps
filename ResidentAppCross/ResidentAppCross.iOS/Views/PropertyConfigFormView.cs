using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    [Register("PropertyConfigFormView")]
    public class PropertyConfigFormView : BaseForm<PropertyConfigFormViewModel>
    {
        private HeaderSection _headerSection;


        //create

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {

                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.MainLabel.Text = "Property";
                    _headerSection.SubLabel.Text = "Configuration";

                }

                return _headerSection;
            }
        }


        //bind

        public override void BindForm()
        {
            base.BindForm();

        }


        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);

        }


        //add to contents
    }
}
