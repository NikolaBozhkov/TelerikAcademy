//
//  ListsTableViewController.m
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import "ListsTableViewController.h"
#import "ListsData.h"
#import "ListTableViewCell.h"
#import "List.h"
#import "Note.h"
#import "NotesTableViewController.h"
#import "AddNewListViewController.h"

@interface ListsTableViewController ()

@property(strong, nonatomic) ListsData *listsData;
@property(strong, nonatomic) NSIndexPath *currentDeletionIndexPath;

@end

@implementation ListsTableViewController

- (void)viewDidLoad {
  [super viewDidLoad];

  // Test data
  self.listsData = [[ListsData alloc] init];
  [self populateTestData];

  // Uncomment the following line to preserve selection between presentations.
  // self.clearsSelectionOnViewWillAppear = NO;

  // Uncomment the following line to display an Edit button in the navigation
  // bar for this view controller.
  // self.navigationItem.rightBarButtonItem = self.editButtonItem;
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  // Return the number of sections.
  return 1;
}

- (NSInteger)tableView:(UITableView *)tableView
    numberOfRowsInSection:(NSInteger)section {
  // Return the number of rows in the section.
  return self.listsData.lists.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView
         cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  NSString *cellIdentifier = @"ListTableCell";
  ListTableViewCell *cell =
      [tableView dequeueReusableCellWithIdentifier:cellIdentifier
                                      forIndexPath:indexPath];

  if (!cell) {
    cell = [[ListTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault
                                    reuseIdentifier:cellIdentifier];
  }

  List *currentList = self.listsData.lists[indexPath.row];

  cell.titleLabel.text = currentList.title;
  cell.categoryLabel.text = currentList.category;

  return cell;
}

- (void)populateTestData {
  for (int i = 0; i < 15; i++) {
    NSString *listTitle = [NSString stringWithFormat:@"Title %d", i];
    NSString *category = [NSString stringWithFormat:@"Category %d", i];

    List *list = [[List alloc] initWithTitle:listTitle andCategory:category];

    for (int k = 0; k < 15; k++) {
      NSString *title = [NSString stringWithFormat:@"Title %d, %d", i, k];
      NSString *noteDescription = [NSString stringWithFormat:@"Description %d, %d", i, k];

      Note *note = [[Note alloc] initWithTitle:title andNoteDescription:noteDescription];
      [list addNote:note];
    }

    [self.listsData addList:list];
  }
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
  NSString *notesTableSegue = @"NotesTableSegue";

  if ([segue.identifier isEqualToString:notesTableSegue]) {
    NotesTableViewController *notesVC = segue.destinationViewController;

    NSIndexPath *indexPath = self.tableView.indexPathForSelectedRow;
    List *selectedList = self.listsData.lists[indexPath.row];

    notesVC.list = selectedList;
    notesVC.navigationItem.title = selectedList.title;
  }
}

- (void)unwindToLists:(UIStoryboardSegue *)segue {
  AddNewListViewController *source = segue.sourceViewController;
  List *list = source.list;
    
  if (list != nil) {
    [self.listsData addList:list];
    [self.tableView reloadData];
  }
}

// Override to support conditional editing of the table view.
- (BOOL)tableView:(UITableView *)tableView
    canEditRowAtIndexPath:(NSIndexPath *)indexPath {
  // Return NO if you do not want the specified item to be editable.
  return YES;
}

// Override to support editing the table view.
- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
  if (editingStyle == UITableViewCellEditingStyleDelete) {
    UIAlertView *alert = [[UIAlertView alloc]
            initWithTitle:@"Warning!"
                  message:@"Are you sure you want to delete all notes in the list?"
                 delegate:self
        cancelButtonTitle:@"Cancel"
        otherButtonTitles:@"Delete", nil];

    self.currentDeletionIndexPath = indexPath;
    List *currentList = self.listsData.lists[indexPath.row];
    if (currentList.notes.count > 0) {
      [alert show];
    } else {
      [self.listsData deleteList:(int)indexPath.row];
      [self.tableView deleteRowsAtIndexPaths:@[indexPath]
                            withRowAnimation:UITableViewRowAnimationFade];
    }
  } else if (editingStyle == UITableViewCellEditingStyleInsert) {
    // Create a new instance of the appropriate class, insert it into the array,
    // and add a new row to the table view
  }
}

- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex {
  if (buttonIndex == 1) {
    [self.listsData deleteList:(int)self.currentDeletionIndexPath.row];
    [self.tableView deleteRowsAtIndexPaths:@[ self.currentDeletionIndexPath ]
                          withRowAnimation:UITableViewRowAnimationFade];
  } else {
    // otherwise
  }
}

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath
*)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath {
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath
*)indexPath {
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little
preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
