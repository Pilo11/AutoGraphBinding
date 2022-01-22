using CoreGraphics;
using Foundation;
using UIKit;

namespace AutographBinding;

public class AutographPad
	{
		T1Autograph _autograph;
		AutographDelegate _autographDelegate = new AutographDelegate();

		public UIView AutographView { get; set; }

		public AutographPad(CGRect rect, UIColor backgroundColor, string licenseCode = "2412e5e98f3cdf15174af801c60447cd1f9db35a", float strokeWidth = 6f, string clearButtonText = "Clear")
		{
			AutographView = new UIView(rect);
			AutographView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			AutographView.BackgroundColor = backgroundColor;
			AutographView.Layer.BorderColor = UIColor.LightGray.CGColor;
			AutographView.Layer.BorderWidth = 1f;

			UIButton clearButton = new UIButton(UIButtonType.Custom);
			clearButton.Frame = new CGRect(AutographView.Frame.Width - 50, 0, 50, 20);
			clearButton.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin;
			clearButton.BackgroundColor = backgroundColor;
			clearButton.SetTitle(clearButtonText, UIControlState.Normal);
			clearButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			clearButton.TitleLabel.Font = UIFont.SystemFontOfSize(12, UIFontWeight.Regular);
			clearButton.TouchUpInside += (sender, e) => { _autograph.Reset(new NSObject()); };

			AutographView.AddSubview(clearButton);
			AutographView.BringSubviewToFront(clearButton);

			_autograph = (T1Autograph)T1Autograph.AutographWithView(AutographView, _autographDelegate);
			_autograph.SwipeToUndoEnabled = false;
			_autograph.LicenseCode = licenseCode;
			_autograph.StrokeWidth = strokeWidth;
			_autograph.ShowGuideline = false;
		}

		public UIImage GetSignatureImage()
		{
			_autograph.Done(new NSObject());
			if (_autographDelegate.Signature == null)
				return null;
			return _autographDelegate.Signature.ImageView.Image;
		}

	}

	public class AutographDelegate : T1AutographDelegate
	{
		public T1Signature Signature { get; private set; }
		
		public override void AutographDidCompleteWithNoSignature(T1Autograph autograph)
		{
			Signature = null;
		}
		public override void DidCompleteWithSignature(T1Autograph autograph, T1Signature signature)
		{
			Signature = signature;		
		}
	}