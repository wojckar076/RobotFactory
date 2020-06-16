using RobotFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotFactory.Models
{
    public class Factory : IFactory
    {
        public List<Robot> Robots { get; set; }
        static Random randomizer;

        public Factory()
        {
            randomizer = new Random();
            Robots = new List<Robot>();
        }
        public void CreateRobot()
        {
            Robots.Add(new Robot(GetNewSerieCode(), RandomizePurpose()));
        }
        public void Create<T>(T product)
        {
            throw new NotImplementedException();
        }
        public ProfessionType RandomizePurpose()
        {
            Array enumValues = Enum.GetValues(typeof(ProfessionType));
            return (ProfessionType)enumValues.GetValue(randomizer.Next(enumValues.Length));            
        }
        public string RandomizeSerieCode()
        {
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = new StringBuilder();
            var lettersNumber = 2;
            var digitsNumber =  3;
            var chars =  Enumerable.Range(0, lettersNumber).Select(x => pool[randomizer.Next(0, pool.Length)]);
            var digits = Enumerable.Range(0, digitsNumber).Select(x => randomizer.Next(0, 9));
            foreach (var character in chars)    result.Append(character);
            foreach (var digit in digits)       result.Append(digit);

            return result.ToString();            
        }
        public bool CheckIfSerieCodeAvailable(string code)
        {
            if (Robots.Count == 0)
                return true;
            return !Robots.Select(s => s.SerieNumber).Contains(code);
        }
        public string GetNewSerieCode()
        {
            var serieCode = RandomizeSerieCode();
            while (!CheckIfSerieCodeAvailable(serieCode))
                serieCode = RandomizeSerieCode();

            return serieCode;
        }
        public void DisplayRobots()
        {
            int i = 1;
            foreach (var robot in Robots)
            {
                Console.WriteLine($"{i}. {robot.ToString()}");
                i++;
            }                
        }
    }
}
