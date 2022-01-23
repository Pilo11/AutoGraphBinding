using AutographBinding;
using Foundation;
using UIKit;

namespace AutographBindingExample;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new UIViewController();
        AutographPad aPad = new(Window!.Frame, UIColor.White, "test");
        aPad.AutographView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
        vc.View!.AddSubview(aPad.AutographView);
        
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}