using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.MyEvent = () =>
                {
                    Console.WriteLine("Event!!!");
                };
            mc.MyEvent += () =>
                {
                    Console.WriteLine("Second!!!");
                };
            mc.DoStuff();
            Console.ReadKey(true);
        }
    }

    public class MyClass
    {
        public Action MyEvent { get; set; }

        public void DoStuff()
        {
            Console.WriteLine("Going to sleep");
            Thread.Sleep(1000);
            if (MyEvent != null)
            {
                MyEvent();
            }

            Console.WriteLine("Done!!");
        }
    }
}
