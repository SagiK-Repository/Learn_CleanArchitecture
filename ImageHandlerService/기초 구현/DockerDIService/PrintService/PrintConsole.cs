namespace DockerDIService.PrintService;

public class PrintConsole : IPrint
{
    public void Print(string message) =>
        Console.WriteLine(message);
}