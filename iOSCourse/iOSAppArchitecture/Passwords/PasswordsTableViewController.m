//
//  PasswordsTableViewController.m
//  Passwords
//

#import "PasswordsTableViewController.h"
#import "PasswordTableViewCell.h"
#import "Password.h"
#import "AddPasswordViewController.h"
#import "PasswordDetailsViewController.h"

@interface PasswordsTableViewController ()

@property (strong, nonatomic) NSMutableArray *passwords;

@end

@implementation PasswordsTableViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    // Test passwords
    Password *password1 = [[Password alloc] initWithAccountName:@"TestAccount1" andPassword:@"123456" andEncryptionCode:@"asd"];
    Password *password2 = [[Password alloc] initWithAccountName:@"TestAccount2" andPassword:@"abc123" andEncryptionCode:@"123asd"];
    Password *password3 = [[Password alloc] initWithAccountName:@"TestAccount3" andPassword:@"asdasd" andEncryptionCode:@"qwee"];
    self.passwords = [[NSMutableArray alloc] initWithObjects:password1, password2, password3, nil];
    
    // Uncomment the following line to preserve selection between presentations.
    // self.clearsSelectionOnViewWillAppear = NO;
    
    // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
    // self.navigationItem.rightBarButtonItem = self.editButtonItem;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return self.passwords.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    NSString *cellIndentifier = @"PasswordTableCell";
    PasswordTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIndentifier];
    
    if (!cell) {
        cell = [[PasswordTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:cellIndentifier];
    }
    
    Password *currentPassword = self.passwords[indexPath.row];
    cell.accountNameLabel.text = currentPassword.accountName;
    cell.encryptedPasswordLabel.text = currentPassword.encryptedPassword;
    
    return cell;
}

- (void)unwindToList:(UIStoryboardSegue *)segue {
    AddPasswordViewController *source = segue.sourceViewController;
    Password *password = source.password;
    
    if (password != nil) {
        [self.passwords addObject:password];
        [self.tableView reloadData];
    }
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    NSString *showPasswordDetailsIndentifier = @"showPasswordDetails";
    
    if ([segue.identifier isEqualToString:showPasswordDetailsIndentifier]) {
        NSIndexPath *indexPath = [self.tableView indexPathForSelectedRow];
        Password *tappedPassword = self.passwords[indexPath.row];
        
        PasswordDetailsViewController *passwordDetailsVC = segue.destinationViewController;
        
        passwordDetailsVC.password = tappedPassword;
    }
}


/*
// Override to support conditional editing of the table view.
- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the specified item to be editable.
    return YES;
}
*/

/*
// Override to support editing the table view.
- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        // Delete the row from the data source
        [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
    } else if (editingStyle == UITableViewCellEditingStyleInsert) {
        // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
    }   
}
*/

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath {
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
