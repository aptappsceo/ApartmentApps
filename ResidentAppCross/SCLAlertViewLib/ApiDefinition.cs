using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace SCLAlertViewLib
{
	// @interface SCLButton : UIButton
	[BaseType (typeof(UIButton))]
	interface SCLButton
	{
		// @property SCLActionType actionType;
		[Export ("actionType", ArgumentSemantic.Assign)]
		SCLActionType ActionType { get; set; }

		// @property (copy, nonatomic) SCLActionBlock actionBlock;
		[Export ("actionBlock", ArgumentSemantic.Copy)]
		SCLActionBlock ActionBlock { get; set; }

		// @property (copy, nonatomic) SCLValidationBlock validationBlock;
		[Export ("validationBlock", ArgumentSemantic.Copy)]
		SCLValidationBlock ValidationBlock { get; set; }

		// @property (copy, nonatomic) CompleteButtonFormatBlock completeButtonFormatBlock;
		[Export ("completeButtonFormatBlock", ArgumentSemantic.Copy)]
		CompleteButtonFormatBlock CompleteButtonFormatBlock { get; set; }

		// @property (copy, nonatomic) ButtonFormatBlock buttonFormatBlock;
		[Export ("buttonFormatBlock", ArgumentSemantic.Copy)]
		ButtonFormatBlock ButtonFormatBlock { get; set; }

		// @property (nonatomic, strong) UIColor * defaultBackgroundColor;
		[Export ("defaultBackgroundColor", ArgumentSemantic.Strong)]
		UIColor DefaultBackgroundColor { get; set; }

		// @property id target;
		[Export ("target", ArgumentSemantic.Assign)]
		NSObject Target { get; set; }

		// @property SEL selector;
		[Export ("selector", ArgumentSemantic.Assign)]
		Selector Selector { get; set; }

		// -(void)parseConfig:(NSDictionary *)buttonConfig;
		[Export ("parseConfig:")]
		void ParseConfig (NSDictionary buttonConfig);

		// @property (nonatomic) SCLTimerDisplay * timer;
		[Export ("timer", ArgumentSemantic.Assign)]
		SCLTimerDisplay Timer { get; set; }
	}

	// typedef void (^SCLActionBlock)();
	delegate void SCLActionBlock ();

	// typedef BOOL (^SCLValidationBlock)();
	delegate bool SCLValidationBlock ();

	// typedef NSDictionary * (^CompleteButtonFormatBlock)();
	delegate NSDictionary CompleteButtonFormatBlock ();

	// typedef NSDictionary * (^ButtonFormatBlock)();
	delegate NSDictionary ButtonFormatBlock ();

	// typedef NSAttributedString * (^SCLAttributedFormatBlock)(NSString *);
	delegate NSAttributedString SCLAttributedFormatBlock (string arg0);

	// typedef void (^DismissBlock)();
	delegate void DismissBlock ();

	// @interface SCLAlertView : UIViewController
	[BaseType (typeof(UIViewController))]
	interface SCLAlertView
	{
		// @property UILabel * labelTitle;
		[Export ("labelTitle", ArgumentSemantic.Assign)]
		UILabel LabelTitle { get; set; }

		// @property UITextView * viewText;
		[Export ("viewText", ArgumentSemantic.Assign)]
		UITextView ViewText { get; set; }

		// @property UIActivityIndicatorView * activityIndicatorView;
		[Export ("activityIndicatorView", ArgumentSemantic.Assign)]
		UIActivityIndicatorView ActivityIndicatorView { get; set; }

		// @property (assign, nonatomic) BOOL shouldDismissOnTapOutside;
		[Export ("shouldDismissOnTapOutside")]
		bool ShouldDismissOnTapOutside { get; set; }

		// @property (nonatomic, strong) NSURL * soundURL;
		[Export ("soundURL", ArgumentSemantic.Strong)]
		NSUrl SoundURL { get; set; }

		// @property (copy, nonatomic) SCLAttributedFormatBlock attributedFormatBlock;
		[Export ("attributedFormatBlock", ArgumentSemantic.Copy)]
		SCLAttributedFormatBlock AttributedFormatBlock { get; set; }

		// @property (copy, nonatomic) CompleteButtonFormatBlock completeButtonFormatBlock;
		[Export ("completeButtonFormatBlock", ArgumentSemantic.Copy)]
		CompleteButtonFormatBlock CompleteButtonFormatBlock { get; set; }

		// @property (copy, nonatomic) ButtonFormatBlock buttonFormatBlock;
		[Export ("buttonFormatBlock", ArgumentSemantic.Copy)]
		ButtonFormatBlock ButtonFormatBlock { get; set; }

		// @property (nonatomic) SCLAlertViewHideAnimation hideAnimationType;
		[Export ("hideAnimationType", ArgumentSemantic.Assign)]
		SCLAlertViewHideAnimation HideAnimationType { get; set; }

		// @property (nonatomic) SCLAlertViewShowAnimation showAnimationType;
		[Export ("showAnimationType", ArgumentSemantic.Assign)]
		SCLAlertViewShowAnimation ShowAnimationType { get; set; }

		// @property (nonatomic) SCLAlertViewBackground backgroundType;
		[Export ("backgroundType", ArgumentSemantic.Assign)]
		SCLAlertViewBackground BackgroundType { get; set; }

		// @property (nonatomic, strong) UIColor * customViewColor;
		[Export ("customViewColor", ArgumentSemantic.Strong)]
		UIColor CustomViewColor { get; set; }

		// @property (nonatomic, strong) UIColor * backgroundViewColor;
		[Export ("backgroundViewColor", ArgumentSemantic.Strong)]
		UIColor BackgroundViewColor { get; set; }

		// @property (nonatomic, strong) UIColor * iconTintColor;
		[Export ("iconTintColor", ArgumentSemantic.Strong)]
		UIColor IconTintColor { get; set; }

		// @property (nonatomic) CGFloat circleIconHeight;
		[Export ("circleIconHeight", ArgumentSemantic.Assign)]
		nfloat CircleIconHeight { get; set; }

		// @property (nonatomic) CGRect extensionBounds;
		[Export ("extensionBounds", ArgumentSemantic.Assign)]
		CGRect ExtensionBounds { get; set; }

		// -(void)alertIsDismissed:(DismissBlock)dismissBlock;
		[Export ("alertIsDismissed:")]
		void AlertIsDismissed (DismissBlock dismissBlock);

		// -(void)hideView;
		[Export ("hideView")]
		void HideView ();

		// -(BOOL)isVisible;
		[Export ("isVisible")]
		//[Verify (MethodToProperty)]
		bool IsVisible { get; }

		// -(void)removeTopCircle;
		[Export ("removeTopCircle")]
		void RemoveTopCircle ();

		// -(UITextField *)addTextField:(NSString *)title;
		[Export ("addTextField:")]
		UITextField AddTextField (string title);

		// -(void)addCustomTextField:(UITextField *)textField;
		[Export ("addCustomTextField:")]
		void AddCustomTextField (UITextField textField);

		// -(void)addTimerToButtonIndex:(NSInteger)buttonIndex;
		[Export ("addTimerToButtonIndex:")]
		void AddTimerToButtonIndex (nint buttonIndex);

		// -(void)setSubTitleHeight:(CGFloat)value __attribute__((deprecated("")));
		[Export ("setSubTitleHeight:")]
		void SetSubTitleHeight (nfloat value);

		// -(void)setTitleFontFamily:(NSString *)titleFontFamily withSize:(CGFloat)size;
		[Export ("setTitleFontFamily:withSize:")]
		void SetTitleFontFamily (string titleFontFamily, nfloat size);

		// -(void)setBodyTextFontFamily:(NSString *)bodyTextFontFamily withSize:(CGFloat)size;
		[Export ("setBodyTextFontFamily:withSize:")]
		void SetBodyTextFontFamily (string bodyTextFontFamily, nfloat size);

		// -(void)setButtonsTextFontFamily:(NSString *)buttonsFontFamily withSize:(CGFloat)size;
		[Export ("setButtonsTextFontFamily:withSize:")]
		void SetButtonsTextFontFamily (string buttonsFontFamily, nfloat size);

		// -(SCLButton *)addButton:(NSString *)title actionBlock:(SCLActionBlock)action;
		[Export ("addButton:actionBlock:")]
		SCLButton AddButton (string title, SCLActionBlock action);

		// -(SCLButton *)addButton:(NSString *)title validationBlock:(SCLValidationBlock)validationBlock actionBlock:(SCLActionBlock)action;
		[Export ("addButton:validationBlock:actionBlock:")]
		SCLButton AddButton (string title, SCLValidationBlock validationBlock, SCLActionBlock action);

		// -(SCLButton *)addButton:(NSString *)title target:(id)target selector:(SEL)selector;
		[Export ("addButton:target:selector:")]
		SCLButton AddButton (string title, NSObject target, Selector selector);

		// -(void)showSuccess:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showSuccess:title:subTitle:closeButtonTitle:duration:")]
		void ShowSuccess (UIViewController vc, string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showSuccess:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showSuccess:subTitle:closeButtonTitle:duration:")]
		void ShowSuccess (string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showError:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showError:title:subTitle:closeButtonTitle:duration:")]
		void ShowError (UIViewController vc, string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showError:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showError:subTitle:closeButtonTitle:duration:")]
		void ShowError (string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showNotice:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showNotice:title:subTitle:closeButtonTitle:duration:")]
		void ShowNotice (UIViewController vc, string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showNotice:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showNotice:subTitle:closeButtonTitle:duration:")]
		void ShowNotice (string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showWarning:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showWarning:title:subTitle:closeButtonTitle:duration:")]
		void ShowWarning (UIViewController vc, string title, string subTitle, [NullAllowed] string closeButtonTitle, double duration);

		// -(void)showWarning:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showWarning:subTitle:closeButtonTitle:duration:")]
		void ShowWarning (string title, string subTitle, [NullAllowed] string closeButtonTitle, double duration);

		// -(void)showInfo:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showInfo:title:subTitle:closeButtonTitle:duration:")]
		void ShowInfo (UIViewController vc, string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showInfo:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showInfo:subTitle:closeButtonTitle:duration:")]
		void ShowInfo (string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showEdit:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showEdit:title:subTitle:closeButtonTitle:duration:")]
		void ShowEdit (UIViewController vc, string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showEdit:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showEdit:subTitle:closeButtonTitle:duration:")]
		void ShowEdit (string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showTitle:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle style:(SCLAlertViewStyle)style closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showTitle:title:subTitle:style:closeButtonTitle:duration:")]
		void ShowTitle (UIViewController vc, string title, string subTitle, SCLAlertViewStyle style, string closeButtonTitle, double duration);

		// -(void)showTitle:(NSString *)title subTitle:(NSString *)subTitle style:(SCLAlertViewStyle)style closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showTitle:subTitle:style:closeButtonTitle:duration:")]
		void ShowTitle (string title, string subTitle, SCLAlertViewStyle style, string closeButtonTitle, double duration);

		// -(void)showCustom:(UIViewController *)vc image:(UIImage *)image color:(UIColor *)color title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showCustom:image:color:title:subTitle:closeButtonTitle:duration:")]
		void ShowCustom (UIViewController vc, UIImage image, UIColor color, string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showCustom:(UIImage *)image color:(UIColor *)color title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showCustom:color:title:subTitle:closeButtonTitle:duration:")]
		void ShowCustom (UIImage image, UIColor color, string title, string subTitle, string closeButtonTitle, double duration);

		// -(void)showWaiting:(UIViewController *)vc title:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showWaiting:title:subTitle:closeButtonTitle:duration:")]
		void ShowWaiting (UIViewController vc, string title, string subTitle,[NullAllowed] string closeButtonTitle, double duration);

		// -(void)showWaiting:(NSString *)title subTitle:(NSString *)subTitle closeButtonTitle:(NSString *)closeButtonTitle duration:(NSTimeInterval)duration;
		[Export ("showWaiting:subTitle:closeButtonTitle:duration:")]
		void ShowWaiting (string title, string subTitle, [NullAllowed]string closeButtonTitle, double duration);

    }

    // @interface SCLAlertViewResponder : NSObject
    [BaseType (typeof(NSObject))]
	interface SCLAlertViewResponder
	{
		// -(instancetype)init:(SCLAlertView *)alertview;
		[Export ("init:")]
		IntPtr Constructor (SCLAlertView alertview);

		// -(void)close;
		[Export ("close")]
		void Close ();
	}

	// @interface SCLAlertViewStyleKit : NSObject
	[BaseType (typeof(NSObject))]
	interface SCLAlertViewStyleKit
	{
		// +(UIImage *)imageOfCheckmark;
		[Static]
		[Export ("imageOfCheckmark")]
		UIImage ImageOfCheckmark { get; }

		// +(UIImage *)imageOfCross;
		[Static]
		[Export ("imageOfCross")]
		//[Verify (MethodToProperty)]
		UIImage ImageOfCross { get; }

		// +(UIImage *)imageOfNotice;
		[Static]
		[Export ("imageOfNotice")]
		//	[Verify (MethodToProperty)]
		UIImage ImageOfNotice { get; }

		// +(UIImage *)imageOfWarning;
		[Static]
		[Export ("imageOfWarning")]
		//[Verify (MethodToProperty)]
		UIImage ImageOfWarning { get; }

		// +(UIImage *)imageOfInfo;
		[Static]
		[Export ("imageOfInfo")]
		//[Verify (MethodToProperty)]
		UIImage ImageOfInfo { get; }

		// +(UIImage *)imageOfEdit;
		[Static]
		[Export ("imageOfEdit")]
		//[Verify (MethodToProperty)]
		UIImage ImageOfEdit { get; }

		// +(void)drawCheckmark;
		[Static]
		[Export ("drawCheckmark")]
		void DrawCheckmark ();

		// +(void)drawCross;
		[Static]
		[Export ("drawCross")]
		void DrawCross ();

		// +(void)drawNotice;
		[Static]
		[Export ("drawNotice")]
		void DrawNotice ();

		// +(void)drawWarning;
		[Static]
		[Export ("drawWarning")]
		void DrawWarning ();

		// +(void)drawInfo;
		[Static]
		[Export ("drawInfo")]
		void DrawInfo ();

		// +(void)drawEdit;
		[Static]
		[Export ("drawEdit")]
		void DrawEdit ();
	}

	// @interface SCLTimerDisplay : UIView
	[BaseType (typeof(UIView))]
	interface SCLTimerDisplay
	{
		// @property CGFloat currentAngle;
		[Export ("currentAngle", ArgumentSemantic.Assign)]
		nfloat CurrentAngle { get; set; }

		// @property (nonatomic) UIColor * color;
		[Export ("color", ArgumentSemantic.Assign)]
		UIColor Color { get; set; }

		// @property NSInteger buttonIndex;
		[Export ("buttonIndex", ArgumentSemantic.Assign)]
		nint ButtonIndex { get; set; }

		// -(instancetype)initWithOrigin:(CGPoint)origin radius:(CGFloat)r;
		[Export ("initWithOrigin:radius:")]
		IntPtr Constructor (CGPoint origin, nfloat r);

		// -(instancetype)initWithOrigin:(CGPoint)origin radius:(CGFloat)r lineWidth:(CGFloat)width;
		[Export ("initWithOrigin:radius:lineWidth:")]
		IntPtr Constructor (CGPoint origin, nfloat r, nfloat width);

		// -(void)updateFrame:(CGSize)size;
		[Export ("updateFrame:")]
		void UpdateFrame (CGSize size);

		// -(void)cancelTimer;
		[Export ("cancelTimer")]
		void CancelTimer ();

		// -(void)stopTimer;
		[Export ("stopTimer")]
		void StopTimer ();

		// -(void)startTimerWithTimeLimit:(int)tl completed:(SCLActionBlock)completed;
		[Export ("startTimerWithTimeLimit:completed:")]
		void StartTimerWithTimeLimit (int tl, SCLActionBlock completed);
	}

  

}
