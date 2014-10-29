//
//  List.h
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import <Foundation/Foundation.h>
#import "Note.h"

@interface List : NSObject

- (instancetype)initWithTitle:(NSString *)title
           andCategory:(NSString *)category;

- (instancetype)initWithTitle:(NSString *)title
                  andCategory:(NSString *)category
                     andNotes:(NSArray *)notes;

@property (strong, nonatomic, readonly) NSMutableArray *notes;
@property (strong, nonatomic) NSString *title;
@property (strong, nonatomic) NSString *category;

- (void)addNote:(Note *)note;
- (void)deleteNote:(int)index;
- (Note *)getNoteAtIndex:(int)index;

@end
