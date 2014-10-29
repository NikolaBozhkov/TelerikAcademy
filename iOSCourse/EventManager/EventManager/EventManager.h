//
//  EventManager.h
//  EventManager
//
//  Created by Nikola Bozhkov on 10/26/14.
//
//

#import <Foundation/Foundation.h>
#import "Event.h"

@interface EventManager : NSObject

- (void)createEventWithTitle:(NSString *)title Category:(NSString *)category
                 Description:(NSString *)description Guests:(NSMutableArray *)guests andDate:(NSDate *)date;

- (NSMutableArray *)getAllEvents;
- (NSArray *)getEventsByCategory:(NSString *)category;
- (NSArray *)getAllEventsSortedByDate;
- (NSArray *)getAllEventsSortedByTitle;

@end
