using System;
using System.Collections.Generic;
using System.Text;
using Task3._2;
using Task7._1;

namespace Task5._2
{
    class DepositTransaction : Transaction
    {

        private Account account;
        private bool executed;
        private bool success;
        private bool reversed;

      public bool Executed
        {

            get
            {
                return this.executed;
            }
        }

        public override bool Success
        {
            get
            {
                return this.success;
            }
        }
        public bool Reversed
        {

            get
            {
                return this.reversed;
            }
        }

        public DepositTransaction(Account account, decimal amount) : base(amount)
        {

            this.account = account;

        }


        public override void Print()
        {

            if (this.Success)
            {

                Console.WriteLine("Deposit Successful");
                Console.WriteLine("Amount Deposited: " + +this.amount);
            }
            else
            {

                Console.WriteLine("Transaction Failed");
            }
        }


        public override void Execute()
        {

            this.executed = true;
            this.dateStamp = DateTime.Now;
            if (this.Success && !this.Reversed)
            {

                throw new InvalidOperationException("Transaction already Attempted");

            }
            else if (this.amount < 0)
            {
                throw new InvalidOperationException("Amount Less Than 0");

            }
            else
            {
                this.account.Balance += this.amount;
                this.success = true;
            }

        }

        public override void RollBack()
        {

            if (this.Success && !this.Reversed)
            {
                this.dateStamp = DateTime.Now;
                this.account.Balance -= this.amount;
                this.reversed = true;

            }
            else
            {

                throw new InvalidOperationException("Transaction already Attempted");
            }

        }

        public override string ToString()
        {

            string str = "\nAccount Name: " + this.account.Name + "\nAmount Deposited: " + this.amount
                        + "\nRemaining Balance: " + this.account.Balance + "\nTime: " + this.dateStamp + "\n";


            if (this.Success)
            {
                str += " Successfuly\n";
            }
            else
            {
                str += " Unsuccessful\n";
            }

            return str;

        }


    }
}
