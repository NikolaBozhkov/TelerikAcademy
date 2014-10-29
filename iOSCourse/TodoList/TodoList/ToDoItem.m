//
//  ToDoItem.m
//  TodoList
//

#import "ToDoItem.h"

@interface ToDoItem ()

@property NSDate *completionDate;

@end

@implementation ToDoItem

- (void)markAsCompleted:(BOOL)isCompleted {
    self.completed = isCompleted;
    [self setCompletionDate];
}

- (void)setCompletionDate {
    if (self.completed) {
        self.completionDate = [NSDate date];
    } else {
        self.completionDate = nil;
    }
}

@end
