//
//  TurtleNinja.m
//  MortalCombat
//

#import "TurtleNinja.h"
#import "Skill.h"

@implementation TurtleNinja

- (instancetype)init {
    if (self = [super init]) {
        self.name = @"TurtleNinja";
        self.life = 100;
        self.power = 0;
        self.damage = 15;
        self.powerGeneration = 2;
        self.punchMultiplier = 1.5;
        self.kickMultiplier = 1.5;
        
        Skill *headBump = [[Skill alloc] initWithName:@"Head Bump" andDamage:20 andPowerConsumption:1];
        Skill *smartStrike = [[Skill alloc] initWithName:@"Smart Strike" andDamage:40 andPowerConsumption:10];
        
        self.skills = [[NSArray alloc] initWithObjects:headBump, smartStrike, nil];
    }
    
    return self;
}

@end
