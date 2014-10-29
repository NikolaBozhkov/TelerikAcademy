//
//  PasswordDetailsViewController.m
//  Passwords
//

#import "PasswordDetailsViewController.h"

@interface PasswordDetailsViewController ()
@property (weak, nonatomic) IBOutlet UILabel *encryptedPasswordLabel;
@property (weak, nonatomic) IBOutlet UILabel *accountNameLabel;

@property (weak, nonatomic) IBOutlet UITextField *encryptedCodeTextField;
@property (weak, nonatomic) IBOutlet UIButton *getPasswordButton;

@end

@implementation PasswordDetailsViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.accountNameLabel.text = self.password.accountName;
    self.encryptedPasswordLabel.text = self.password.encryptedPassword;
    
    [self.getPasswordButton addTarget:self
                               action:@selector(getPasswordButtonClick:)
                     forControlEvents:UIControlEventTouchUpInside];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)getPasswordButtonClick:(id)sender {
    NSString *password = [self.password getDecryptedPassword:self.encryptedCodeTextField.text];
    NSString *message;
    NSString *title;
    
    if (password != nil) {
        message = password;
        title = @"Password";
    } else {
        message = @"Invalid encryption code";
        title = @"Error";
    }
    
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:title
                                                    message:message
                                                   delegate:nil
                                          cancelButtonTitle:@"Close"
                                          otherButtonTitles: nil];
    [alert show];
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
