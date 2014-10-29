//
//  Fighting.h
//  MortalCombat
//

#import <Foundation/Foundation.h>

@protocol Fighting <NSObject>

@property (strong, nonatomic) NSString *name;
@property double life;
@property int power;
@property double damage;
@property int powerGeneration;
@property int kickMultiplier;
@property int punchMultiplier;


- (void)punchFighting:(id<Fighting>)fighting;
- (void)kickFighting:(id<Fighting>)fighting;

@end
