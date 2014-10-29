//
//  Todo.h
//  Todos
//

#import <Foundation/Foundation.h>

@interface Todo : NSObject
@property (strong, nonatomic) NSString *title;
@property (strong, nonatomic) NSString *description;
@property (strong, nonatomic) NSDate *endDate;
@end
