using System;
using System.Collections.Generic;
using System.Text;
using Task3._2;
using Task7._1;

namespace Task5._2
{
    class TransferTransaction : Transaction
    {

        private Account fromAccount;
        private Account toAccount;
        private DepositTransaction deposit;
        private WithdrawTransactions withDraw;
        private bool executed;
        private bool success;
        private bool reversed;

        public override bool Success
        {

            get
            {
                return this.executed;
            }
        }

        public bool Executed
        {

            get
            {
                return this.executed;
            }
        }

        public bool Reversed
        {

            get
            {
                return this.reversed;
            }
        }

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
        {

            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
            withDraw = new WithdrawTransactions(fromAccount,amount);
            deposit = new DepositTransaction(toAccount,amount);

        }


        public override void Print()
        {

            if (this.deposit.Executed && this.withDraw.Executed)
            {

                Console.WriteLine("Transfer Successful");
                Console.WriteLine("Transfered  " + +this.amount + " from " + this.fromAccount.Name + " Account to " + this.toAccount.Name + "Account");
            }
            else
            {

                Console.WriteLine("Transfer Failed");
            }
        }


        public override void Execute()
        {

            if (this.Executed)
            {

                throw new InvalidOperationException("Transfer already Attempted");

            }
            else if (this.fromAccount.Balance < this.amount)
            {
                throw new InvalidOperationException("Insufficient Balance");

            }
            else
            {
                this.dateStamp = DateTime.Now;
                this.withDraw.Execute();
                this.executed = true;
                this.deposit.Execute();
            }

        }

        public override void RollBack()
        {

            if (deposit.Executed && withDraw.Executed)
            {
                this.dateStamp = DateTime.Now;
                this.deposit.RollBack();
                this.withDraw.RollBack();
                this.reversed = true;

            } else if (toAccount.Balance < amount) 
            {
                throw new InvalidOperationException("Insufficient Fund to Roll Back");
            }
            else
            {

                throw new InvalidOperationException("Transaction already Attempted");
            }

        }

        public override string ToString()
        {

            string str = "\nAccount Holder: \"" + this.fromAccount.Name + "\" Transfered " + this.amount + "Rs "
                        + " To Account Holder \"" + this.toAccount.Name + "\" at " + this.dateStamp;


            if (this.executed && !this.reversed)
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
