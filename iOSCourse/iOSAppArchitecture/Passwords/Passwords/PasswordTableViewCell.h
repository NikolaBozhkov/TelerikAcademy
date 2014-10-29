//
//  PasswordTableViewCell.h
//  Passwords
//

#import <UIKit/UIKit.h>

@interface PasswordTableViewCell : UITableViewCell

@property (weak, nonatomic) IBOutlet UILabel *accountNameLabel;
@property (weak, nonatomic) IBOutlet UILabel *encryptedPasswordLabel;

@end
