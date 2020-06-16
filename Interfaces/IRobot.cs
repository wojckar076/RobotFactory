namespace DesignPatternFactoryMethod.Interfaces
{
    public enum ProfessionType
    {
        Translator = 0,
        CoffeeMaker,
        Bartender
    }
    public interface IRobot
    {
        public void Reset(string newNumber);
    }
}
