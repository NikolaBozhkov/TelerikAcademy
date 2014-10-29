//
//  main.m
//  MortalCombat
//

#import <Foundation/Foundation.h>
#import "Sumakashi.h"
#import "Bundake.h"
#import "Jason.h"
#import "Stormer.h"
#import "TurtleNinja.h"
#import "Fighting.h"
#import "Character.h"

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        // Testing here
        Sumakashi *sumakashi = [[Sumakashi alloc] init];
        Bundake *bundake = [[Bundake alloc] init];
        Jason *jason = [[Jason alloc] init];
        Stormer *stormer = [[Stormer alloc] init];
        TurtleNinja *turtleNinja = [[TurtleNinja alloc] init];
        
        NSArray *characters = [[NSArray alloc] initWithObjects:sumakashi, bundake, jason, stormer, turtleNinja, nil];
        
        for (Character *character in characters) {
            NSLog(@"%@", character.name);
        }
        
        [sumakashi punchFighting:bundake];
        [bundake punchFighting:sumakashi];
        
        [stormer kickFighting:jason];
        [stormer punchFighting:turtleNinja];
        [stormer useSkillByIndex:0 OnFighting:turtleNinja];
    }
    return 0;
}
