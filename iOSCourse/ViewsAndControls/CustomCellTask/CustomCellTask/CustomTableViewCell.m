//
//  CustomTableViewCell.m
//  CustomCellTask
//
//  Created by Nikola Bozhkov on 10/31/14.
//
//

#import "CustomTableViewCell.h"

@implementation CustomTableViewCell

@synthesize textLabel = _textLabel;
@synthesize imageView = _imageView;

- (void)awakeFromNib {
    // tried a lot of stuff to make it look good, but meh.. nothing works
    UIImage *image = [UIImage imageNamed:@"download.jpeg"];
    self.imageView.image = image;
    self.imageView.contentMode = UIViewContentModeScaleAspectFit;
    //self.contentMode = UIViewContentModeScaleToFill;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
