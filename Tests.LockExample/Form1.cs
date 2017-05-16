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
                var t = new Thread(acc.DoTransactions)
                {
                    Name = "线程" + i,
                    Priority = ThreadPriority.Normal   // 线程的优先级
                };
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

/*
 * 
 * 多线程同步问题
 * 
 * # 线程的优先级
 * 
 * 当线程之间争夺CPU时间片时，CPU是按照线程的优先级进行服务的。
 * 在C#应用程序中，线程有5个不同的优先级，
 * 由高到低分别是：Highest、AboveNormal、Normal 、BelowNormal和Lowest。
 * 创建线程时，如果不指定其优先级，则系统默认为Normal。
 * 
 * 通过设置线程的优先级可以改变线程执行的顺序，所设置的优先级仅仅适用于这些线程所属的进程。
 * （注：当把某个线程的优先级设置为Htghest时，系统上正在运行的其他线程都会终止，所以使用这个优先级的时候要特别小心。
 * 除非遇到“币需”马上处理的任务，否则不要使用这个优先级）。
 * 
 * 
 * # 线程同步
 *  多线程处理解决了吞吐量和响应速度的问题，但同时也带来了资源共享问题，如死锁和资源争用。
 *  多线程特别适用于需要不同的资源（如文件句柄和网络连接）的任务。
 *  为单个资源分配多个线程可能会导致同步问题，这种情况下，线程可能会北频繁阻止以等待其他线程，从而使用多线程的初衷背道而驰。
 *  
 *  所谓同步，是指多个线程之间存在先后执行顺序的关联关系。如果一个线程必须在另一个线程完成某个工作后才能继续执行，则必须考虑如何让其他保持同步，以确保在系统上同时运行多个线程而不会出现死锁或逻辑错误。
 *  
 *  为了解决同步问题，一般使用辅助线程执行不需要大量占用其他线程所使用的资源的耗时任务或时间要求紧迫的任务。但实际上，程序中的某些资源必须由多个线程访问。为了解决这些问题，System.Threading命名空间提供了多个用于同步线程的类。这些类包括Mutex,Monitor,Interlocked,AutoResetEvent.  
 *  但是实际应用程序中，我们使用最多的可能不是这些类，而是C#提供的lock语句。
 * 
 * # Lock语句
 * 
 * 为了在多线程应用程序中让同步变得简单，C#专门提供了一个lock语句。
 * lock关键字能确保当一个线程位于代码的临界区时，另一个线程不进入临界区。
 * 如果其他线程试图进入锁定的代码段，则它将一直等待（阻塞），
 * 知道锁定的对象被释放以后才能进入临界区。
 * 
 * 处于临界区的代码不宜太多。如果在锁定和解锁期间处理的代码过多，由于某个线程执行临界区中的代码时，其他等待运行临界区中代码的线程都会处于阻塞状态，这样就可能会降低应用程序的性能。
 * 
 * 
 * eg:
 * 举个例子相信大家会更明白，路人甲和路人乙要上厕所，刚好找到了一个公共厕所，
 * 杯具的是公共厕所里面只有一个位置，路人甲是会员（优先级高），先溜进去了，然后把门锁上（Lock）紧接着里面发出一阵阵巨响....（大家都懂的，最近食物不敢乱吃啊 - -！）。路人乙可着急了，捂着肚子，在外面打转，憋得面红耳赤！过了好一段时间，路人甲抽着香烟，吹着口哨，从厕所里面走出来（Lock解锁了）,路人乙急忙钻进去，紧接着又是一阵巨响.....
 * 虽然这个例子举的有点不和谐，但相信大家已经弄明白Lock的作用了。
            
 */
