//
//  CustomTableViewCell.h
//  CustomCellTask
//
//  Created by Nikola Bozhkov on 10/31/14.
//
//

#import <UIKit/UIKit.h>

@interface CustomTableViewCell : UITableViewCell

@property (weak, nonatomic) IBOutlet UIImageView *imageView;
@property (weak, nonatomic) IBOutlet UILabel *textLabel;

@end
