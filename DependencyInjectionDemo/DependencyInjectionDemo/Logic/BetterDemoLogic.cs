namespace DependencyInjectionDemo.Logic;

public class BetterDemoLogic : IDemoLogic
{
    public int Value1 { get; private set; }
    public int Value2 { get; private set; }

    public BetterDemoLogic()
    {
        Value1 = 20;
        Value2 = 50;
    }
}
