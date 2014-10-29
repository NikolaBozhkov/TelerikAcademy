//
//  SkillUsing.h
//  MortalCombat
//

#import <Foundation/Foundation.h>
#import "Fighting.h"

@protocol SkillUsing <NSObject>

@property (strong, nonatomic) NSArray *skills;

- (void)useSkillByIndex:(int)index
             OnFighting:(id<Fighting>)fighting;

@end
