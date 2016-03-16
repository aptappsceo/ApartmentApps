using System;
using UIKit;

namespace ResidentAppCross.iOS
{
    public partial class SectionViewBase : UIView
    {
        public SectionViewBase()
        {
        }

        public SectionViewBase(IntPtr handle) : base(handle)
        {
        }

        private NSLayoutConstraint _heightConstraint;

        public NSLayoutConstraint HeightConstraint
        {
            get
            {
                if (_heightConstraint == null)
                {
                    _heightConstraint = NSLayoutConstraint.Create(this, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 100);
                    this.AddConstraint(_heightConstraint);
                }
                return _heightConstraint;
            }
        }
    }
}