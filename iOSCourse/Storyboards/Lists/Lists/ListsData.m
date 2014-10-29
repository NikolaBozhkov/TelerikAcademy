//
//  ListsData.m
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import "ListsData.h"

@interface ListsData ()

@property (strong, nonatomic) NSMutableArray *lists;

@end

@implementation ListsData

- (instancetype)init {
    if (self = [super init]) {
        self.lists = [[NSMutableArray alloc] init];
    }
    
    return self;
}

- (instancetype)initWithLists:(NSArray *)lists {
    if (self = [super init]) {
        self.lists = [NSMutableArray arrayWithArray:lists];
    }
    
    return self;
}

- (void)addList:(List *)list {
    [self.lists addObject:list];
}

- (void)deleteList:(int)index {
    [self.lists removeObjectAtIndex:index];
}

@end
