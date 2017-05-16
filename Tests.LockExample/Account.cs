using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.LockExample
{
    class Account
    {

        #region Fields
        private readonly object _obj = new object();
        private int _balance;
        private readonly Random _rd = new Random();
        private readonly Form1 _form1;
        #endregion


        #region Ctor
        public Account(int initial, Form1 form1)
        {
            this._form1 = form1;
            this._balance = initial;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        private int Withdraw(int amount)
        {
            if (_balance < 0)
            {
                _form1.AddListBoxItem("余额" + _balance + " 兄弟，你以为你这是信用卡啊！还钱吧！");
            }

            // 将lock(lockedobj)这句话注视掉，看看会发生什么情况
            lock (_obj)
            {
                if (_balance >= amount)
                {
                    var str = Thread.CurrentThread.Name + "取款---";
                    str += $"取款前余额：{_balance,-6}取款：{amount,-6}";
                    _balance = _balance - amount;
                    str += "取款后余额：" + _balance;
                    _form1.AddListBoxItem(str);
                    return amount;
                }
                else
                {
                    return 0;
                }
            }

        }

        public void DoTransactions()
        {
            for (var i = 0; i < 100; i++)
            {
                Withdraw(_rd.Next(1, 100));
            }
        }

        #endregion
    }
}
