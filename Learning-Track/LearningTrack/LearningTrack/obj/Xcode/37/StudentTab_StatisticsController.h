// WARNING
// This file has been generated automatically by MonoDevelop to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <UIKit/UIKit.h>
#import <MapKit/MapKit.h>
#import <Foundation/Foundation.h>
#import <CoreGraphics/CoreGraphics.h>


@interface StudentTab_StatisticsController : UIViewController {
	UITextField *_urlTextField;
    UIButton *_backButton;
    UIButton *_forwardButton;
    UIButton *_refreshButton;
    UIWebView *_webView;
}

@property (nonatomic, retain) IBOutlet UITextField *urlTextField;
@property (retain, nonatomic) IBOutlet UIWebView *webView;
@property (retain, nonatomic) IBOutlet UIButton *backButton;
@property (retain, nonatomic) IBOutlet UIButton *forwardButton;
@property (retain, nonatomic) IBOutlet UIButton *refreshButton;

@end
