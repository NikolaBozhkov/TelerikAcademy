//
//  ToDoItem.h
//  TodoList
//

#import <Foundation/Foundation.h>

@interface ToDoItem : NSObject

@property NSString *name;
@property (readonly) NSDate *creationDate;
@property BOOL completed;

- (void)markAsCompleted:(BOOL)isCompleted;

@end
