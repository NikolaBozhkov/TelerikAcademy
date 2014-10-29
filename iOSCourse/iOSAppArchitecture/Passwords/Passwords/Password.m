//
//  Password.m
//  Passwords
//

#import "Password.h"

@interface Password ()

@property (strong, nonatomic) NSString *encryptionCode;
@property (strong, nonatomic) NSString *passwordValue;
@property (strong, nonatomic) NSString *encryptedPassword;

@end

@implementation Password

NSString *availableCharacters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

+ (NSString *)generateRandomPassword {
    NSMutableString *password = [[NSMutableString alloc] initWithString:@""];
    int passLength = arc4random_uniform(7) + 6;
    
    for (int i = 0; i < passLength; i++) {
        int randomIndex = arc4random_uniform((int)availableCharacters.length);
        
        NSString *character = [availableCharacters substringWithRange:NSMakeRange(randomIndex, 1)];
        [password appendString:character];
    }
    
    return [NSString stringWithString:password];
}

@synthesize passwordValue = _passwordValue;
- (void)setPasswordValue:(NSString *)passwordValue {
    // This validation is strange and I can't go over the chars
//    for (id character in [passwordValue componentsSeparatedByString:@""]) {
//        if (![availableCharacters containsString:character]) {
//            [[NSException exceptionWithName:@"Argument exception"
//                                    reason:@"password can contain only letters and digits"
//                                  userInfo:nil]
//            raise];
//        }
//    }
    
    _passwordValue = passwordValue;
}

- (instancetype)initWithAccountName:(NSString *)accountName
                  andEncryptionCode:(NSString *)encryptionCode {
    if (self = [super init]) {
        self.accountName = accountName;
        self.encryptionCode = encryptionCode;
        self.passwordValue = [Password generateRandomPassword];
        [self encryptPassword];
    }
    
    return self;
}

- (instancetype)initWithAccountName:(NSString *)accountName
                        andPassword:(NSString *)passwordValue
                  andEncryptionCode:(NSString *)encryptionCode {
    if (self = [super init]) {
        self.accountName = accountName;
        self.encryptionCode = encryptionCode;
        self.passwordValue = passwordValue;
        [self encryptPassword];
    }
    
    return self;
}

- (NSString *)getDecryptedPassword:(NSString *)encryptionCode {
    if (![encryptionCode isEqualToString:self.encryptionCode]) {
        // Should probably throw exception, but then you have to catch it, better return nil
        return nil;
    }
    
    return self.passwordValue;
}

- (void)encryptPassword {
    NSMutableString *encrypted = [NSMutableString stringWithString:@""];
    
    for (int i = 0; i < self.passwordValue.length; i++) {
        char passChar = [self.passwordValue characterAtIndex:i];
        char encryptionCodeChar = [self.encryptionCode characterAtIndex:i % self.encryptionCode.length];
        
        char encryptedChar = (char)(passChar | encryptionCodeChar);
        [encrypted appendString:[NSString stringWithFormat:@"%c", encryptedChar]];
    }
    
    self.encryptedPassword = [NSString stringWithString:encrypted];
}

@end