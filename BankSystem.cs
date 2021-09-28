using System;
using System.Runtime.CompilerServices;
using Task5._2;
using Task6._2;

namespace Task3._2
{
    class BankSystem
    {
        static void Main(string[] args)
        {

            Bank bank = new Bank();

            Account account1 = new Account("AC-01",94500);
            Account account2 = new Account("AC-02",4500);
            bank.AddAccount(account1);
            bank.AddAccount(account2);
            while (true) { 
            
                switch (ReadUserInput()) {
                   
                    case MenuOption.Add_new_Account:

                        Console.WriteLine("Enter Name of the Account");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the Initial Balance");
                        decimal balance = Convert.ToDecimal(Console.ReadLine());

                        account2 = new Account(name, balance);
                        bank.AddAccount(account2);

                        break;

                    case MenuOption.Withdraw:

                        DoWithdraw(bank);

                        break;

                    case MenuOption.Deposit:

                        DoDeposit(bank);

                        break;

                    case MenuOption.Transfer:

                        DoTransfer(bank);

                        break;

                    case MenuOption.Transaction_History:

                        bank.PrintTranscationHistory();
                        Console.WriteLine("Do you want to RollBack a transaction | y,Y-Yes & n,N-No");
                        string input = Console.ReadLine();
                        while (!(input[0].CompareTo('n') == 0 || input[0].CompareTo('y') == 0 ||
                            input[0].CompareTo('N') == 0 || input[0].CompareTo('Y') == 0)) 
                        {
                            Console.WriteLine("Please just say yes or no");
                            input = Console.ReadLine();
                        }

                        if (input[0].CompareTo('y') == 0 || input[0].CompareTo('Y') == 0)
                        {
                            DoRollback(bank);
                        }

                        break;


                    case MenuOption.Print:

                        DoPrint(bank);

                        break;

                    case MenuOption.Quit:

                        System.Environment.Exit(1);

                        break;
            

                }//switch
            }//while

        }//Main-thread

        static MenuOption ReadUserInput() {

            int userChoice = -1;

            do
            {
                Console.WriteLine("Choose the operation you want to perform");
                Console.WriteLine("1. " + MenuOption.Add_new_Account);
                Console.WriteLine("2. " + MenuOption.Withdraw);
                Console.WriteLine("3. " + MenuOption.Deposit);
                Console.WriteLine("4. " + MenuOption.Transfer);
                Console.WriteLine("5. " + MenuOption.Transaction_History);
                Console.WriteLine("6. " + MenuOption.Print);
                Console.WriteLine("7. " + MenuOption.Quit);
                userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice < 1 || userChoice > 6)
                {

                    Console.WriteLine("Choose the Correct option you want to perform");
                    Console.WriteLine("1. " + MenuOption.Add_new_Account);
                    Console.WriteLine("2. " + MenuOption.Withdraw);
                    Console.WriteLine("3. " + MenuOption.Deposit);
                    Console.WriteLine("4. " + MenuOption.Transfer);
                    Console.WriteLine("5. " + MenuOption.Transaction_History);
                    Console.WriteLine("6. " + MenuOption.Print);
                    Console.WriteLine("7. " + MenuOption.Quit);
                    userChoice = Convert.ToInt32(Console.ReadLine());

                }
                    return (MenuOption)(userChoice - 1);

            } while (true);



        }//ReadUserInput

        public static void DoDeposit(Bank bank) {
            int amount = 0;
            Account account = bank.FindAccount(bank);
            while (account == null)
            {
                account = bank.FindAccount(bank);
            }
            Console.WriteLine("Please Enter Ammount to Deposit");
            amount = Convert.ToInt32(Console.ReadLine());
            DepositTransaction depositTransaction = new DepositTransaction(account,amount);
            bank.ExecuteTransaction(depositTransaction);
            depositTransaction.Print();

        }//DoDeposit

        public static void DoWithdraw(Bank bank) {
            int amount = 0;
            Account account = bank.FindAccount(bank);
            while (account == null)
            {
                account = bank.FindAccount(bank);
            }
            Console.WriteLine("Please Enter Ammount to WithDraw");
            amount = Convert.ToInt32(Console.ReadLine());
            WithdrawTransactions withdrawTransactions = new WithdrawTransactions(account, amount);
            bank.ExecuteTransaction(withdrawTransactions);
            withdrawTransactions.Print();
        }//DoWithdraw

        public static void DoTransfer(Bank bank)
        {
            int amount = 0;
            Console.WriteLine("Enter Account to Transfer From");
            Account fromAccount = bank.FindAccount(bank);
            Console.WriteLine("Enter Account to Transfer To");
            Account toAccount = bank.FindAccount(bank);
            while (fromAccount == null)
            {
                Console.WriteLine("Re Enter Account to Transfer From");
                fromAccount = bank.FindAccount(bank);
            }

            while (toAccount == null)
            {
                Console.WriteLine("Re Enter Account to Transfer To");
                toAccount = bank.FindAccount(bank);
            }
            Console.WriteLine("Please Enter Ammount to Transfer");
            amount = Convert.ToInt32(Console.ReadLine());
            TransferTransaction transferTransaction = new TransferTransaction(fromAccount,toAccount, amount);
            bank.ExecuteTransaction(transferTransaction);
            transferTransaction.Print();

        }//DoWithdraw
        
        public static void DoRollback(Bank bank)
        {

            bank.FindTransaction().RollBack();

        }//DoRollBack



        public static void DoPrint(Bank bank) {

            foreach (Account account in bank.AccountList) 
            {
                account.Print();
            }

        }//DoPrint


    }

    public enum MenuOption
    {
        Add_new_Account,
        Withdraw,
        Deposit,
        Transfer,
        Transaction_History,
        Print,
        Quit
    }


}
