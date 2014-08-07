// A bank account has a holder name (first name, middle name and last name),
// available amount of money (balance), bank name, IBAN, BIC code and 3 credit card
// numbers associated with the account. Declare the variables needed to keep the information 
// for a single bank account using the appropriate data types and descriptive names.

using System;

public class BankAccount
{
    public static void Main()
    {
        // Lots of strings...
        string firstName = "First";
        string middleName = "Middle";
        string lastName = "Last";
        string holderName = string.Format("{0} {1} {2}", firstName, middleName, lastName);
        decimal balance = 2345542221.01m;
        string bankName = "IBank inc.";
        string iban = "BG80 BNBG 9661 1020 3456 78";
        string bicCode = "AABAFI22";
        string cardNum1 = "4132 5713 3672 1612";
        string cardNum2 = "5500 5214 9681 2134";
        string cardNum3 = "5401 3621 1645 5287";
    }
}