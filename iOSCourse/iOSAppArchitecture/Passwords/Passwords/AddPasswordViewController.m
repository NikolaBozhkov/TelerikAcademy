//
//  AddPasswordViewController.m
//  Passwords
//

#import "AddPasswordViewController.h"
#import "Password.h"

@interface AddPasswordViewController ()

@property (weak, nonatomic) IBOutlet UIBarButtonItem *doneButton;
@property (weak, nonatomic) IBOutlet UIButton *randomPasswordButton;

@property (weak, nonatomic) IBOutlet UITextField *accountNameTextField;
@property (weak, nonatomic) IBOutlet UITextField *passwordTextField;
@property (weak, nonatomic) IBOutlet UITextField *encryptionCodeTextField;

@end

@implementation AddPasswordViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self.randomPasswordButton addTarget:self
                                  action:@selector(randomPasswordButtonClick:)
                        forControlEvents:UIControlEventTouchUpInside];
    // Do any additional setup after loading the view.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    if (sender != self.doneButton) {
        return;
    }
    
    // No validation cuz it's just excercise, otherwise just usage of shouldPerformSegue... and some alerts does the trick : )
    if (![self checkIfAnyFieldIsEmpty]) {
        self.password = [[Password alloc] initWithAccountName:self.accountNameTextField.text
                                                  andPassword:self.passwordTextField.text
                                            andEncryptionCode:self.encryptionCodeTextField.text];
    }
}

- (BOOL)checkIfAnyFieldIsEmpty {
    if (self.accountNameTextField.text.length == 0
            || self.passwordTextField.text.length == 0
            || self.encryptionCodeTextField.text.length == 0) {
        return true;
    }
    
    return false;
}

- (void)randomPasswordButtonClick:(id)sender {
    self.passwordTextField.text = [Password generateRandomPassword];
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
