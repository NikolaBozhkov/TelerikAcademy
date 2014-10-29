//
//  Stormer.m
//  MortalCombat
//

#import "Stormer.h"
#import "Skill.h"

@implementation Stormer

- (instancetype)init {
    if (self = [super init]) {
        self.name = @"Stormer";
        self.life = 100;
        self.power = 0;
        self.damage = 7;
        self.powerGeneration = 6;
        self.punchMultiplier = 1.8;
        self.kickMultiplier = 1.9;
        
        Skill *chainLighting = [[Skill alloc] initWithName:@"Chain Lighting" andDamage:11 andPowerConsumption:5];
        Skill *soulStrike = [[Skill alloc] initWithName:@"Soul Strike" andDamage:70 andPowerConsumption:40];
        
        self.skills = [[NSArray alloc] initWithObjects:chainLighting, soulStrike, nil];
    }
    
    return self;
}

@end
