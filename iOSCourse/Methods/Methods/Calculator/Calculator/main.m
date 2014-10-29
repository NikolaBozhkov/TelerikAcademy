//
//  main.m
//  Methods
//

#import <Foundation/Foundation.h>

#import "Calculator.h"

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        const NSString *COMMAND_ADD = @"add";
        const NSString *COMMAND_SUBTRACT = @"subtract";
        const NSString *COMMAND_MULTIPLY = @"multiply";
        const NSString *COMMAND_DIVIDE = @"divide";
        const NSString *COMMAND_SAVE = @"save";
        const NSString *COMMAND_GET_LAST_SAVE = @"get-last-save";
        const NSString *COMMAND_RESET = @"reset";
        const NSString *COMMAND_EXIT = @"exit";
        
        Calculator *calculator = [[Calculator alloc] init];
        
        printf("Commands: add 'number', subtract 'number', multiply 'by number', divide 'by number', save, get-last-save, reset\n");
        printf("Enter valid data, otherwise shit blows up, don't wanna do validation");
        printf("\n>>>");
        
        char inputBuffer[2048] = { 0 };
        scanf("%40[^\n]", inputBuffer);
        NSString *input = [NSString stringWithUTF8String:inputBuffer];
        
        while (![input isEqual: COMMAND_EXIT]) {
            NSArray *inputComponents = [input componentsSeparatedByString: @" "];
            NSString *inputCommand = inputComponents[0];
            
            float inputNumber = 0;
            if (inputComponents.count >= 2) {
                inputNumber = [inputComponents[1] floatValue];
            }
            
            if ([inputCommand isEqual: COMMAND_ADD]) {
                [calculator addNumber:inputNumber];
                NSString *output = [NSString stringWithFormat:@"%f", calculator.result];
                NSLog(@"%@", output);
            }
            else if ([inputCommand isEqual: COMMAND_SUBTRACT]) {
                [calculator subtractNumber:inputNumber];
                NSString *output = [NSString stringWithFormat:@"%f", calculator.result];
                NSLog(@"%@", output);
            }
            else if ([inputCommand isEqual: COMMAND_DIVIDE]) {
                [calculator divideByNumber:inputNumber];
                NSString *output = [NSString stringWithFormat:@"%f", calculator.result];
                NSLog(@"%@", output);
            }
            else if ([inputCommand isEqual: COMMAND_MULTIPLY]) {
                [calculator multipleByNumber:inputNumber];
                NSString *output = [NSString stringWithFormat:@"%f", calculator.result];
                NSLog(@"%@", output);
            }
            else if ([inputCommand isEqual: COMMAND_SAVE]) {
                [calculator save];
            }
            else if ([inputCommand isEqual: COMMAND_GET_LAST_SAVE]) {
                float lastSave = [calculator getLastSave];
                NSString *output = [NSString stringWithFormat:@"%f", lastSave];
                NSLog(@"%@", output);
            }
            else if ([inputCommand isEqual: COMMAND_RESET]) {
                [calculator reset];
            }
            
            printf("\n>>>");
            char inputBuffer[2048] = { 0 };
            scanf(" %40[^\n]", inputBuffer);
            input = [NSString stringWithUTF8String:inputBuffer];
        }
    }
    
    return 0;
}
