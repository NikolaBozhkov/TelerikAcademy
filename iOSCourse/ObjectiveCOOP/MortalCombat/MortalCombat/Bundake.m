//
//  Bundake.m
//  MortalCombat
//

#import "Bundake.h"
#import "Skill.h"

@implementation Bundake

- (instancetype)init {
    if (self = [super init]) {
        self.name = @"Bundake";
        self.life = 100;
        self.power = 10;
        self.damage = 8;
        self.powerGeneration = 8;
        self.punchMultiplier = 1.4;
        self.kickMultiplier = 1.8;
        
        Skill *smash = [[Skill alloc] initWithName:@"Smash" andDamage:10 andPowerConsumption:7];
        Skill *destroy = [[Skill alloc] initWithName:@"Destroy" andDamage:30 andPowerConsumption:15];
        
        self.skills = [[NSArray alloc] initWithObjects:smash, destroy, nil];
    }
    
    return self;
}

@end
