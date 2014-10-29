//
//  TodoList.m
//  Todos
//

#import "TodoList.h"
#import "Todo.h"

@implementation TodoList
-(instancetype)init {
    self = [super init];
    if (self) {
        self.todos = [[NSMutableArray alloc] init];
    }
    
    return self;
}

-(void)addTodo:(Todo *)todo {
    [self.todos addObject: todo];
}

-(void)deleteTodoByPosition:(int)position {
    [self.todos removeObjectAtIndex: position];
}

-(void)deleteTodo:(Todo *)todo {
    [self.todos removeObject:todo];
}

@end
