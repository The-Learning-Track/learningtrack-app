//
//  ViewController.h
//  TheLearningTrack
//
//  Created by Senior Design on 10/2/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//


#import <UIKit/UIKit.h>

@interface ViewController : UIViewController{
    
    IBOutlet UITextField    *username;
    IBOutlet UITextField    *password;
    IBOutlet UILabel        *testLabel;
    
}

//Each property must be synthesized in the .m file
@property (retain, nonatomic) UILabel *testLabel;   
@property (retain, nonatomic) UITextField *username;
@property (retain, nonatomic) UITextField *password;

//Name of the action: What initiates that action 
-(IBAction)loginButtonPressed:(id)sender;
-(IBAction)hideKeyboard:(id)sender; 
//-(IBAction)alert;

@end
