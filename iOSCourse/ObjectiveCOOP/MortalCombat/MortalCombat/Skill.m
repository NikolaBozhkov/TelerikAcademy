//
//  Skill.m
//  MortalCombat
//

#import "Skill.h"

@implementation Skill

- (instancetype)initWithName:(NSString *)name andDamage:(double)damage andPowerConsumption:(int)powerConsumption {
    if (self = [super init]) {
        self.name = name;
        self.damage = damage;
        self.powerConsumption = powerConsumption;
    }
    
    return self;
}

- (void)applyEffectsOnFighting:(id<Fighting>)consumer ByFighting:(id<Fighting>)caster {
    consumer.life -= self.damage;
    caster.power -= self.powerConsumption;
}

@end
