using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests.LockExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            lbLock.Items.Clear();
            var threads = new Thread[10];
            var acc = new Account(1000, this);
            for (var i = 0; i < 10; i++)
            {
                var t = new Thread(acc.DoTransactions) {Name = "线程" + i};
                threads[i] = t;
            }

            for (var i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }

        public delegate void AddListBoxItemDelegate(string str);

        public void AddListBoxItem(string str)
        {
            if (lbLock.InvokeRequired)
            {
                AddListBoxItemDelegate d = AddListBoxItem;
                lbLock.Invoke(d, str);
            }
            else
            {
                lbLock.Items.Add(str);
            }
        }


    }
}
