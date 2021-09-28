using System;
using System.Collections.Generic;
using System.Linq;
using Task3._2;
using Task5._2;
using Task7._1;

namespace Task6._2
{
    class Bank
    {

        private List<Account> accountList;
        private List<Transaction> listOfTransactions;


        public List<Account> AccountList{

            get {
                return accountList.ToList();
            }

        }

        public Bank() 
        {
            this.accountList = new List<Account>();
            this.listOfTransactions = new List<Transaction>();

    }

        public void AddAccount(Account account) 
        {
            accountList.Add(account);
        }

        public Account GetAccount(String name) 
        {
            Account account1 = null;
            foreach (Account account in this.accountList )
            {

                if (account.Name.CompareTo(name) == 0) 
                {
                    account1 = account;
                }
            }
            return account1;
        }

        public void ExecuteTransaction(Transaction transaction) 
        {
            listOfTransactions.Add(transaction);
            transaction.Execute();        
        }

        public void RollBackTransaction(Transaction transaction)
        {
            transaction.RollBack();
        }

        public void PrintTranscationHistory() 
        {
            for (int i = 0; i < listOfTransactions.Count; i++)
            {
                 Console.WriteLine("Index:" + i + " " + listOfTransactions[i].ToString());
            }
        }

        public Account FindAccount(Bank bank) 
        {
            Account account3 = null;
            Console.WriteLine("Enter the Account name to be Searched");
            string name = Console.ReadLine();
            foreach (Account account in bank.accountList) 
            {
                if (account.Name.CompareTo(name) == 0) 
                {
                    account3 = account;
                    Console.WriteLine(account.Name + " Account Found");
                }
            }
            if (account3 == null) 
            {
                Console.WriteLine("No Account Exists With The Name " + "\"" + name + "\"");
            }

            return account3;
        
        }

        public Transaction FindTransaction()
        {
            Transaction transaction = null;
            Console.WriteLine("Enter index of the Transaction to RollBack");
            int index = Convert.ToInt32(Console.ReadLine());
            while (index < 0 || index >= listOfTransactions.Count)
            {
                Console.WriteLine("Please Enter Correct Index between 0-" + (listOfTransactions.Count - 1));
                index = Convert.ToInt32(Console.ReadLine());
            }

            return listOfTransactions[index];
        }

    }

}
