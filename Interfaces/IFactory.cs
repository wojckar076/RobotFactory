namespace DesignPatternFactoryMethod.Interfaces
{
    public interface IFactory
    {
        public void CreateRobot();
        public void Create<T>(T product);
        public string RandomizeSerieCode();
        public ProfessionType RandomizePurpose();
        public bool CheckIfSerieCodeAvailable(string code);
    }
}
