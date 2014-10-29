//
//  EventManager.m
//  EventManager
//
//  Created by Nikola Bozhkov on 10/26/14.
//
//

#import "EventManager.h"
#import "Event.h"

// COULDN'T FINISH THE APP, 10 MINUTES REMAINING, SORRY ABOUT THAT, GONNA FINISH IT NOW

@interface EventManager ()

@property NSMutableArray *eventsList;

@end

@implementation EventManager

- (void)createEventWithTitle:(NSString *)title Category:(NSString *)category
                 Description:(NSString *)description Guests:(NSMutableArray *)guests andDate:(NSDate *)date {
    Event *event = [[Event alloc] init];
    
    event.title = title;
    event.category = category;
    event.eventDescription = description;
    event.date = date;
    event.guests = [NSMutableArray arrayWithArray:guests];
    
    [self.eventsList addObject:event];
}


- (NSMutableArray *)getAllEvents {
    return [NSMutableArray arrayWithArray:self.eventsList];
}

- (NSArray *)getAllEventsSortedByDate {
    NSArray *sortedList = [self.eventsList sortedArrayUsingComparator:^NSComparisonResult(Event *event1, Event *event2) {
        return [event1.date compare:event2.date];
    }];
    
    return sortedList;
}

- (NSArray *)getAllEventsSortedByTitle {
    NSArray *sortedList = [self.eventsList sortedArrayUsingComparator:^NSComparisonResult(Event *event1, Event *event2) {
        return [event1.title compare:event2.title];
    }];
    
    return sortedList;
}

- (NSArray *)getEventsByCategory:(NSString *)category {
    NSString *attributeName = @"category";
    NSPredicate *predicate = [NSPredicate predicateWithFormat:@"%K LIKE $@",
                              attributeName, category];
                              
    NSArray *listByCategory = [self.eventsList filteredArrayUsingPredicate:predicate];
    
    return listByCategory;
}

@end
