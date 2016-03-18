namespace ResidentAppCross.iOS.Views
{
    public interface IFormEventsListener
    {
        void FormDidDisappear();
        void FormDidAppear();
        void FormWillAppear();
        void FormWillDisappear();
        void WillShowNotification();
        void WillHideNotification();
    }
}