//
//  Character.m
//  MortalCombat
//

#import "Character.h"
#import "Fighting.h"
#import "Skill.h"

@implementation Character

@synthesize name = _name;
- (void)setName:(NSString *)value {
    if (value.length < 3) {
        [[NSException exceptionWithName:@"Argument exception" reason:@"name must be at least 3 characters long" userInfo:nil] raise];
    }
    
    _name = value;
}

@synthesize life = _life;
- (void)setLife:(double)value {
    if (value < 0 || value > 100) {
        [[NSException exceptionWithName:@"Argument exception" reason:@"life must be between 0 and 100" userInfo:nil] raise];
    }
    
    _life = value;
}

@synthesize power = _power;
- (void)setPower:(int)value {
    if (value < 0 || value > 100) {
        [[NSException exceptionWithName:@"Argument exception" reason:@"power must be between 0 and 100" userInfo:nil] raise];
    }
    
    _power = value;
}

@synthesize damage = _damage;
- (void)setDamage:(double)value {
    if (value < 0 || value > 20) {
        [[NSException exceptionWithName:@"Argument exception" reason:@"damage must be between 0 and 20" userInfo:nil] raise];
    }
    
    _damage = value;
}

@synthesize powerGeneration = _powerGeneration;
- (void)setpowerGeneration:(int)value {
    if (value < 2 || value > 10) {
        [[NSException exceptionWithName:@"Argument exception" reason:@"powerGeneration must be between 2 and 10" userInfo:nil] raise];
    }
    
    _powerGeneration = value;
}

@synthesize kickMultiplier = _kickMultiplier;
- (void)setkickMultiplier:(double)value {
    if (value < 1 || value > 2) {
        [[NSException exceptionWithName:@"Argument exception" reason:@"kickMultiplier must be between 1 and 2" userInfo:nil] raise];
    }
    
    _kickMultiplier = value;
}

@synthesize punchMultiplier = _punchMultiplier;
- (void)setpunchMultiplier:(double)value {
    if (value < 1 || value > 2) {
        [[NSException exceptionWithName:@"Argument exception" reason:@"punchMultiplier must be between 1 and 2" userInfo:nil] raise];
    }
    
    _punchMultiplier = value;
}

@synthesize skills = _skills;
- (void)setSkills:(NSArray *)value {
    if (value == nil) {
        [[NSException exceptionWithName:@"Null argument exception" reason:@"skills cannot be nil" userInfo:nil] raise];
    }
    
    _skills = value;
}

-(void)kickFighting:(id<Fighting>)fighting{
    fighting.life -= self.damage * self.kickMultiplier;
    self.power += self.powerGeneration * self.kickMultiplier;
    NSLog(@"%@(%lf life) kicked %@(%lf life)", self.name, self.life, fighting.name, fighting.life);
}

- (void)punchFighting:(id<Fighting>)fighting {
    fighting.life -= self.damage * self.punchMultiplier;
    self.power += self.powerGeneration * self.punchMultiplier;
    NSLog(@"%@(%lf life) punched %@(%lf life)", self.name, self.life, fighting.name, fighting.life);
}

- (void)useSkillByIndex:(int)index OnFighting:(id<Fighting>)fighting {
    Skill *skill = self.skills[index];
    
    int powerLeft = self.power - skill.powerConsumption;
    if (powerLeft >= 0) {
        [skill applyEffectsOnFighting:fighting ByFighting:self];
        NSLog(@"%@(%lf life) used skill '%@' on %@(%lf life)", self.name, self.life, skill.name, fighting.name, fighting.life);
    } else {
        NSLog(@"Not enough power");
    }
}

@end
