using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using _Logging;

namespace ConsoleApplication2
{
    class Program
    {

        static QueWrapper qw = new QueWrapper();

        static void Main(string[] args)
        {
            LogManager l = new LogManager();

            


            Log.TR(null, "WaitOne / Deq / Reset");
            //Log.TR(null, "WaitOne  / Reset / Deq");

            System.Threading.Timer t1 = new System.Threading.Timer(_timerCallback1);
            System.Threading.Timer t2 = new System.Threading.Timer(_timerCallback2);

            //DateTime d1 = DateTime.Now;
            //DateTime d2 = DateTime.Now;

            //if (d2 - d1 > new TimeSpan(0, 0, 0, 5))
            //{
            //    Log.TR(null, "aaa");
            //}
            
            t1.Change(0, Timeout.Infinite);
            t2.Change(100, 2000);

            Console.WriteLine(@"CTRL-C to Exit.");
            Console.ReadLine();
        }

        static public  void _timerCallback1(object o)
        {
            int item = 0;
            try
            {
                //if (que.Count() == 0)
                {
                    ++item;
                    //lock (que)
                    {
                        qw.que.Enqueue(item);
                        qw.que.Enqueue(item);
                        qw.que.Enqueue(item);
                        Log.TR(null, "Enq", Log.CP("count", qw.que.Count()));
                        //System.Threading.Thread.Sleep(500);
                        Log.TR(null, "Set-->");
                        qw.me.Set();
                        qw.me.Set();
                        qw.me.Set();
                        Log.TR(null, "<--Set");
                    }
                }
            }
            catch (Exception e)
            {
                Log.TR_ERR(null, e);
            }
        }

        static public void _timerCallback2(object o)
        {
            int item = 0;
            try
            {
                if (qw.que.Count() > 0)
                {
                    //lock (que)
                    {
                        qw.me.WaitOne();
                        //System.Threading.Thread.Sleep(300);

#if false
                        Log.TR(null, "Reset-->");
                        qw.me.Reset();
                        Log.TR(null, "<--Reset");
#endif
                        item = qw.que.Dequeue();
                        Log.TR(null, "Deq", Log.CP("count", qw.que.Count()));
                        //item = qw.que.Dequeue();
                        //Log.TR(null, "Deq", Log.CP("count", qw.que.Count()));
                        //item = qw.que.Dequeue();
                        //Log.TR(null, "Deq", Log.CP("count", qw.que.Count()));
                        //item = qw.que.Dequeue();
                        //Log.TR(null, "Deq", Log.CP("count", qw.que.Count()));
#if true
                        Log.TR(null, "Reset-->");
                        qw.me.Reset();
                        Log.TR(null, "<--Reset");
#endif
                        
                        //System.Threading.Thread.Sleep(200);
                    }
                }
            }
            catch (Exception e)
            {
                Log.TR_ERR(null, e);                
            }
        }
    }

    class QueWrapper
    {
        public Queue<int> que = new Queue<int>();
        public ManualResetEvent me = new ManualResetEvent(false);
    }


}
