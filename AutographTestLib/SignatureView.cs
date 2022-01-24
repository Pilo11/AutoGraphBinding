using AutographBinding;
using CoreGraphics;
using UIKit;

namespace AutographTestLib;

public sealed class SignatureView : UIView
{
    public SignatureView(CGRect frame) : base(frame)
    {
        AutographPad aPad = new(frame, UIColor.White, "test");
        aPad.AutographView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
        AddSubview(aPad.AutographView);
    }
}