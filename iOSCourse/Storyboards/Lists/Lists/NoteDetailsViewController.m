//
//  NoteDetailsViewController.m
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import "NoteDetailsViewController.h"

@interface NoteDetailsViewController ()

@property (weak, nonatomic) IBOutlet UITextField *titleTextField;
@property (weak, nonatomic) IBOutlet UITextField *descriptionTextField;
@property (weak, nonatomic) IBOutlet UILabel *dateLabel;
@property (strong, nonatomic) UIBarButtonItem *editButton;

@property (strong, nonatomic) UIBarButtonItem *doneButton;

@end

@implementation NoteDetailsViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self populateFields];
    
    [self createBarButtons];
    self.navigationItem.rightBarButtonItem = self.editButton;
    
    [self.editButton setTarget:self];
    [self.editButton setAction:@selector(editButtonClicked)];
    
    // Do any additional setup after loading the view.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSString *)formatDate:(NSDate *)date {
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:@"dd.MM.yy"];
    
    return [formatter stringFromDate:date];
}

- (void)populateFields {
    self.titleTextField.text = self.note.title;
    self.descriptionTextField.text = self.note.noteDescription;
    
    if (self.note.date) {
        self.dateLabel.text = [self formatDate:self.note.date];
    } else {
        self.dateLabel.text = @"No Date";
    }
}

- (void)editButtonClicked {
    self.navigationItem.hidesBackButton = YES;
    self.navigationItem.rightBarButtonItem = self.doneButton;
    
    [self.titleTextField setEnabled:YES];
    [self.descriptionTextField setEnabled:YES];
    [self.titleTextField becomeFirstResponder];
}

- (void)doneButtonClicked {
    self.navigationItem.hidesBackButton = NO;
    self.navigationItem.rightBarButtonItem = self.editButton;
    
    [self.titleTextField setEnabled:NO];
    [self.descriptionTextField setEnabled:NO];
    
    self.note.title = self.titleTextField.text;
    self.note.noteDescription = self.descriptionTextField.text;
}

- (void)createBarButtons {
    self.doneButton = [[UIBarButtonItem alloc] initWithTitle:@"Done"
                                                       style:UIBarButtonItemStyleDone
                                                      target:self
                                                      action:@selector(doneButtonClicked)];
    
    self.editButton = [[UIBarButtonItem alloc] initWithTitle:@"Edit"
                                                       style:UIBarButtonItemStylePlain
                                                      target:self
                                                      action:@selector(editButtonClicked)];
    
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
