//
//  AddNewNoteViewController.m
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import "AddNewNoteViewController.h"
#import "Note.h"

@interface AddNewNoteViewController ()

@property (weak, nonatomic) IBOutlet UITextField *titleTextField;
@property (weak, nonatomic) IBOutlet UITextField *descriptionTextField;
@property (weak, nonatomic) IBOutlet UIDatePicker *datePicker;
@property (weak, nonatomic) IBOutlet UIBarButtonItem *doneButton;
@property (weak, nonatomic) IBOutlet UISwitch *saveDateSwitch;

@end

@implementation AddNewNoteViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self.datePicker setMinimumDate:[NSDate date]];
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
            && self.descriptionTextField.text.length > 0) {
        self.note = [[Note alloc] initWithTitle:self.titleTextField.text
                              andNoteDescription:self.descriptionTextField.text];
        
        if (self.saveDateSwitch.isOn) {
            self.note.date = self.datePicker.date;
        }
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
