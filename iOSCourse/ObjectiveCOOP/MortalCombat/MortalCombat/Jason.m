//
//  Jason.m
//  MortalCombat
//

#import "Jason.h"
#import "Skill.h"

@implementation Jason

- (instancetype)init {
    if (self = [super init]) {
        self.name = @"Jason";
        self.life = 100;
        self.power = 0;
        self.damage = 10;
        self.powerGeneration = 3;
        self.punchMultiplier = 1.5;
        self.kickMultiplier = 1.7;
        
        Skill *skyShot = [[Skill alloc] initWithName:@"Sky Shot" andDamage:17 andPowerConsumption:10];
        Skill *jumpArrow = [[Skill alloc] initWithName:@"Jump Arrow" andDamage:25 andPowerConsumption:15];
        
        self.skills = [[NSArray alloc] initWithObjects:skyShot, jumpArrow, nil];
    }
    
    return self;
}

@end
