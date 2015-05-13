using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace PorkerHands
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines("PokerHands-input.txt");

            for (var i = 0; i < 3; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                ProcessLines(text);

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                Console.WriteLine(ts.TotalMilliseconds);

                string elapsedTime = String.Format("{0:00}Hrs:{1:00}Mins:{2:00}Secs:{3:00}Ms",
                                    ts.Hours, ts.Minutes, ts.Seconds,
                                    ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
            }

            Console.ReadLine();
        }

        static void ProcessLines(string[] lines)
        {
            int taskCount = 0;
            Task<string>[] tasks = new Task<string>[lines.Count()];

            foreach (var line in lines)
            {
                int localTaskCount = taskCount;
                tasks[localTaskCount] = Task<string>.Factory.StartNew(() => 
                {
                    var allCards = line.Split(' ');

                    var blackCards = new List<Card>();
                    var whiteCards = new List<Card>();

                    for (var i = 0; i < 10; i++)
                    {
                        var playerCard = new Card { OriginalCardValueString = allCards[i].ToUpper() };

                        if (i < 5)
                            blackCards.Add(playerCard);
                        else
                            whiteCards.Add(playerCard);
                    }

                    return new Analyzer(blackCards, whiteCards).GetWinner();
                });
                taskCount++;
            }

            Task.WaitAll(tasks);

            foreach (var task in tasks)
            {
                //Console.WriteLine(task.Result);
            }
        }
    }
}
