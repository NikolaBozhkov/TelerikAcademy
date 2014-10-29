//
//  NotesTableViewController.h
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import <UIKit/UIKit.h>
#import "List.h"

@interface NotesTableViewController : UITableViewController

- (IBAction)unwindToNotesList:(UIStoryboardSegue *)segue;

@property (strong, nonatomic) List *list;

@end
