namespace RobotFactory.Interfaces
{
    public class Robot : IRobot
    {
        public string SerieNumber { get; set; }
        public ProfessionType Profession { get; }

        public Robot(string serieNumber, ProfessionType purpose)
        {
            SerieNumber = serieNumber;
            Profession = purpose;
        }
        public void Reset(string newNumber)
        {
            SerieNumber = newNumber;
        }

        public override string ToString()
        {
            return $"{SerieNumber}, {Profession}";
        }
    }
}