﻿using RobotFactory.Models;
using System;
using System.Linq;

namespace RobotFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory fac = new Factory();
            for (int i = 0; i < 10; i++)
            {
                fac.CreateRobot();
            }
            fac.DisplayRobots();
            Console.Write($"\nThere is {fac.Robots.Count} Robots in the factory. Which one would you like to reset? ");
            int choice;
            do
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice < 1 || choice > fac.Robots.Count)
                    {
                        Console.WriteLine("Incorrent Robot number!");
                        continue;
                    }                        
                    else break;
                } else
                    Console.WriteLine($"Enter integer from 1 to {fac.Robots.Count}!");
            } while (true);

            fac.Robots.ElementAt(choice-1).Reset(fac.GetNewSerieCode());
            
            fac.DisplayRobots();
        }
    }
}
