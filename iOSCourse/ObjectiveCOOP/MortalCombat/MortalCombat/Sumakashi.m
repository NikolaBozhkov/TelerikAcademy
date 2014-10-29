//
//  Sumakashi.m
//  MortalCombat
//

#import "Sumakashi.h"
#import "Skill.h"

@implementation Sumakashi

- (instancetype)init {
    if (self = [super init]) {
        self.name = @"Sumakashi";
        self.life = 100;
        self.power = 0;
        self.damage = 10;
        self.powerGeneration = 4;
        self.punchMultiplier = 1.7;
        self.kickMultiplier = 1.8;
        
        Skill *pierce = [[Skill alloc] initWithName:@"Pierce" andDamage:20 andPowerConsumption:15];
        Skill *backstab = [[Skill alloc] initWithName:@"Backstab" andDamage:40 andPowerConsumption:30];
        
        self.skills = [[NSArray alloc] initWithObjects:pierce, backstab, nil];
    }
    
    return self;
}

@end
