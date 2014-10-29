//
//  Calculator.m
//  Methods
//

#import "Calculator.h"

@implementation Calculator

-(instancetype) init {
    self = [super init];
    if (self) {
        self.result = 0;
        self.savedValues = [[NSMutableArray alloc] init];
    }
    
    return self;
}

-(void)save {
    [self.savedValues addObject: [NSNumber numberWithFloat: self.result]];
}

-(void)addNumber:(float)number {
    self.result += number;
}

-(void)subtractNumber:(float)number {
    self.result -= number;
}

-(void)divideByNumber:(float)number {
    self.result /= number;
}

-(void)multipleByNumber:(float)number {
    self.result *= number;
}

-(void)reset {
    self.result = 0;
}

-(void)deleteSaves {
    self.savedValues = [[NSMutableArray alloc] init];
}

-(float)getLastSave {
    return [self.savedValues[self.savedValues.count - 1] floatValue];
}

@end
