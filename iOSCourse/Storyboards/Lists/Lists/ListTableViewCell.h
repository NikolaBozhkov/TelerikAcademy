//
//  ListTableViewCell.h
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import <UIKit/UIKit.h>

@interface ListTableViewCell : UITableViewCell

@property (weak, nonatomic) IBOutlet UILabel *titleLabel;
@property (weak, nonatomic) IBOutlet UILabel *categoryLabel;

@end
