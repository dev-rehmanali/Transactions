using System;
using Task3._2;
using Task7._1;

namespace Task5._2
{
    class WithdrawTransactions : Transaction
    {
        private Account account;
        private bool executed;
        private bool success;
        private bool reversed;

        public WithdrawTransactions(Account account,decimal amount) : base(amount) {

            this.account = account;

        }

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

        public override void Print() {

            if (this.Success) 
            {

                Console.WriteLine("Withdraw Successful");
                Console.WriteLine("Amount Withdrawn: " + this.amount);
            }else
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
            else if (this.account.Balance < this.amount || this.account.Balance == 0)
            {
                throw new InvalidOperationException("Insufficient Balance to Withdraw");

            }
            else 
            {
                this.account.Balance -= this.amount;
                this.success = true;
            }

        }

        public override void RollBack()
        {

            if (this.Success && !this.Reversed)
            {
                this.dateStamp = DateTime.Now;
                this.account.Balance += this.amount;
                this.reversed = true;

            }
            else 
            {

                throw new InvalidOperationException("Transaction already Attempted");
            }

        }

        public override string ToString()
        {

            string str = "\nAccount Name: " + this.account.Name + "\nAmount Withdrawn: " + this.amount
                        + "\nRemaining Balance: " + this.account.Balance + "\nTime: " + this.dateStamp;

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
