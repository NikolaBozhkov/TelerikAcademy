//
//  Note.h
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import <Foundation/Foundation.h>

@interface Note : NSObject

- (instancetype)initWithTitle:(NSString *)title
           andNoteDescription:(NSString *)noteDescription;

- (instancetype)initWithTitle:(NSString *)title
           andNoteDescription:(NSString *)noteDescription
                      andDate:(NSDate *)date;

@property (strong, nonatomic) NSString *title;
@property (strong, nonatomic) NSString *noteDescription;
@property (strong, nonatomic) NSDate *date;

@end
