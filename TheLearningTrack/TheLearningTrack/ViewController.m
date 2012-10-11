//
//  ViewController.m
//  TheLearningTrack
//
//  Created by Senior Design on 10/2/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#import "ViewController.h"

@implementation ViewController

//Each property from .h must be synthesized
@synthesize username, password, testLabel;

-(IBAction)loginButtonPressed:(id)sender {
    
    NSString *testString = [[NSString alloc] initWithFormat:@"Your username is: %@\n and your password is: %@",
                           [username text], [password text]];
    //Sets the label with the NSString
    [testLabel setText:testString];
    
}

-(IBAction)hideKeyboard:(id)sender{
    //Hides keyboard after typing into textfield
    //Link Event: Did end on exit to textfield
    [username resignFirstResponder];
    [password resignFirstResponder];
    
}

//Alert EXAMPLE
/*-(IBAction)alert {
    
    //UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Sign In" message:@"Please enter your Username and Password" delegate:self cancelButtonTitle:@"Sign In" otherButtonTitles:@"Cancel", nil];
    UIAlertView *alert = [[UIAlertView alloc]   initWithTitle:@"Login" 
                                                message:@"Please enter your credentials" 
                                                delegate:self 
                                                cancelButtonTitle:@"Cancel" 
                                                otherButtonTitles: @"Submit", nil];
    alert.alertViewStyle = UIAlertViewStyleLoginAndPasswordInput;
    UITextField *alertTextField = [alert textFieldAtIndex:0];
    alertTextField.keyboardType = UIKeyboardTypeDefault;
    alertTextField.placeholder = @"Username";
     
    [alert show];
    //NSString *username = [[alert textFieldAtIndex:0] text];
    //NSString *password = [[alert textFieldAtIndex:1] text];
}
*/


- (void)didReceiveMemoryWarning
{
    // Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
    
    // Release any cached data, images, etc that aren't in use.
}

#pragma mark - View lifecycle

/*
 // Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
 - (void)viewDidLoad
 {
 [super viewDidLoad];
 }
 */

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    // Return YES for supported orientations
    return YES;
    //return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

@end
