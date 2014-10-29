//
//  Event.h
//  EventManager
//
//  Created by Nikola Bozhkov on 10/26/14.
//
//

#import <Foundation/Foundation.h>

@interface Event : NSObject

@property NSString *title;
@property NSString *category;
@property NSString *eventDescription;
@property NSDate *date;
@property NSMutableArray *guests;

@end
