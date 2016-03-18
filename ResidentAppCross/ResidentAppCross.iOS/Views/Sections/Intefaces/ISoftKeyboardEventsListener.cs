using CoreGraphics;

namespace ResidentAppCross.iOS
{
    public interface ISoftKeyboardEventsListener
    {
        void DidShowKeyboard();
        void DidHideKeyboard();
        void WillShowKeyboard(ref CGRect overrideDefaultScroll);
        void WillHideKeyboard(ref CGRect overrideDefaultScroll);
    }
}