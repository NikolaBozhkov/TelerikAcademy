//
//  Note.m
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import "Note.h"

@implementation Note

- (instancetype)initWithTitle:(NSString *)title andNoteDescription:(NSString *)noteDescription {
    if (self = [super init]) {
        self.title = title;
        self.noteDescription = noteDescription;
    }
    
    return self;
}

- (instancetype)initWithTitle:(NSString *)title andNoteDescription:(NSString *)noteDescription andDate:(NSDate *)date {
    self = [self initWithTitle:title andNoteDescription:noteDescription];
    
    if (self) {
        self.date = date;
    }
    
    return self;
}

@end
