//
//  ListsData.h
//  Lists
//
//  Created by Nikola Bozhkov on 10/29/14.
//
//

#import <Foundation/Foundation.h>
#import "List.h"

@interface ListsData : NSObject

- (instancetype)initWithLists:(NSArray *) lists;

@property (strong, nonatomic, readonly) NSMutableArray *lists;

- (void)addList:(List *)list;
- (void)deleteList:(int)index;

@end
