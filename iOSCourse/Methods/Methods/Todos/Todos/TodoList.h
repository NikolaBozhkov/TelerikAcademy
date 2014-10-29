//
//  TodoList.h
//  Todos

#import <Foundation/Foundation.h>
#import "Todo.h"

@interface TodoList : NSObject
@property (strong, nonatomic) NSMutableArray *todos;
-(instancetype) init;
-(void) addTodo: (Todo *) todo;
-(void) deleteTodoByPosition: (int) position;
-(void) deleteTodo: (Todo *) todo;
@end
