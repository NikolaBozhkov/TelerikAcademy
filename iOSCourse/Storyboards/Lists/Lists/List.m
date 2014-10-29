//
//  List.m
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import "List.h"
#import "Note.h"

@interface List ()

@property (strong, nonatomic) NSMutableArray *notes;

@end

@implementation List

- (instancetype)initWithTitle:(NSString *)title andCategory:(NSString *)category {
    if (self = [super init]) {
        self.title = title;
        self.category = category;
        self.notes = [[NSMutableArray alloc] init];
    }
    
    return self;
}

- (instancetype)initWithTitle:(NSString *)title andCategory:(NSString *)category andNotes:(NSArray *)notes {
    self = [self initWithTitle:title andCategory:category];
    
    if (self) {
        self.notes = [NSMutableArray arrayWithArray:notes];
    }
    
    return self;
}

- (void)addNote:(Note *)note {
    [self.notes addObject:note];
}

- (void)deleteNote:(int)index {
    [self.notes removeObjectAtIndex:index];
}

- (Note *)getNoteAtIndex:(int)index {
    return self.notes[index];
}

@end
