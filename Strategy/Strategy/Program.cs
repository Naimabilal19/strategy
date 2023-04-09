using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Context
    {
        private IStrategy _strategy;

        public Context(){ }

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        {
            Velo v = new Velo(); Bus b = new Bus(); taxi t = new taxi();
            Console.WriteLine("Context: Choose");
            var res = new List<object> { v.ShowChoose(), b.ShowChoose(), t.ShowChoose() };
            foreach (var a in res)
            {
                Console.WriteLine(a);
            }

        }
    }
    public interface IStrategy
    {
        string ShowChoose();
    }

    class Velo : IStrategy
    {
        int money = 2;
        string time = "1 hour";
        public string ShowChoose()
        {
            return $"Money: {money}\nTime: {time}\n";
        }
    }

    class Bus : IStrategy
    {
        int money = 20;
        string time = "30 min";
        public string ShowChoose()
        {
            return $"Money: {money}\nTime: {time}\n";
        }
    }
    class taxi : IStrategy
    {
        int money = 50;
        string time = "5 min";
        public string ShowChoose()
        {
            return $"Money: {money}\nTime: {time}\n";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            Console.WriteLine("Client: Я хочу добраться до аэропорта");
            context.DoSomeBusinessLogic();
            Console.WriteLine("Client: Я хочу добраться до аэропорта на такси");
            context.SetStrategy(new taxi());
            context.DoSomeBusinessLogic();
            Console.WriteLine();
            
        }
    }
}
