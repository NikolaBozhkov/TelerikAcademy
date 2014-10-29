//
//  AddNewListViewController.m
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import "AddNewListViewController.h"
#import "List.h"

@interface AddNewListViewController ()

@property (weak, nonatomic) IBOutlet UITextField *titleTextField;
@property (weak, nonatomic) IBOutlet UITextField *categoryTextField;
@property (weak, nonatomic) IBOutlet UIBarButtonItem *doneButton;

@end

@implementation AddNewListViewController

- (void)viewDidLoad {
    [super viewDidLoad];
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
    
    if (self.titleTextField.text.length > 0
            && self.titleTextField.text.length > 0) {
        self.list = [[List alloc] initWithTitle:self.titleTextField.text
                                    andCategory:self.categoryTextField.text];
    }
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
