using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._1
{
    abstract class Transaction
    {
        protected decimal amount;
        protected bool success;
        private bool executed;
        private bool reversed;
        protected DateTime dateStamp;

        public Transaction(decimal amount) 
        {
            this.amount = amount;
        }

        public abstract bool Success 
        {
            get;
        }

        public bool Executed
        {
            get { return this.executed; }
        }

        public bool Reversed
        {
            get { return this.reversed; }
        }

        public DateTime Date
        {
            get { return this.dateStamp; }
        }

        public abstract void Print();

        public virtual void Execute()
        {

        }
        
        public virtual void RollBack() 
        {

        }

        public abstract string ToString();
    }
}
