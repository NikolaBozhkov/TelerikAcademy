//
//  Calculator.h
//  Methods
//

#import <Foundation/Foundation.h>

@interface Calculator : NSObject
@property float result;
@property (strong, nonatomic) NSMutableArray *savedValues;
-(instancetype) init;
-(void) save;
-(void) addNumber: (float) number;
-(void) subtractNumber: (float) number;
-(void) divideByNumber: (float) number;
-(void) multipleByNumber: (float) number;
-(void) reset;
-(void) deleteSaves;
-(float) getLastSave;
@end
