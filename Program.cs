using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


class App
{
    static void Main()
    {
        //    MainAsync().Wait();
        //}

        //static async Task MainAsync()
        //{
        // TODO: ВОВАН ЧИТАЙ КНИГИ! HOW TO USE TASK ContinueWith
        // Запустим процесс который будем отслежитьвать
        Process.Start("calc.exe");
        Task firstTask = Task.Factory.StartNew(() =>
        {
            while (true)
            {
                var procList = Process.GetProcessesByName("calc");
                if (procList.Any())
                {
                    Thread.Sleep(500);
                    continue;
                }
                break;
            }
        });
        Task continuationTask = firstTask.ContinueWith((continuation) => Print());
        while (true)
        {
            Console.WriteLine("Выводим кактой то текст");
            Thread.Sleep(1000);
        }

    }
    static void Print()
    {
        Console.WriteLine("Процесс был убит");
    }
}