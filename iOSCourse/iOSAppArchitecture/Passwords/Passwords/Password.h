//
//  Password.h
//  Passwords
//

#import <Foundation/Foundation.h>

@interface Password : NSObject

+ (NSString *)generateRandomPassword;

- (instancetype)initWithAccountName:(NSString *)accountName
                  andEncryptionCode:(NSString *)encryptionCode;

- (instancetype)initWithAccountName:(NSString *)accountName
                        andPassword:(NSString *)passwordValue
                  andEncryptionCode:(NSString *)encryptionCode;

@property (strong, nonatomic) NSString *accountName;
@property (strong, nonatomic, readonly) NSString *encryptedPassword;

- (NSString *)getDecryptedPassword:(NSString *)encryptionCode;

@end
