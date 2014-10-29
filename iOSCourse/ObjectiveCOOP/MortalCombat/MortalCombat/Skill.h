//
//  Skill.h
//  MortalCombat
//

#import <Foundation/Foundation.h>
#import "Fighting.h"

@interface Skill : NSObject

@property (strong, nonatomic) NSString *name;
@property double damage;
@property int powerConsumption;

- (instancetype)initWithName:(NSString *)name
                   andDamage:(double)damage
         andPowerConsumption:(int)powerConsumption;

- (void)applyEffectsOnFighting:(id<Fighting>)consumer
                    ByFighting:(id<Fighting>)caster;

@end
