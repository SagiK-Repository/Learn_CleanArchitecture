namespace DockerDIService.PrintService;

public class PrintConsole : IPrint
{
    public async Task Print(string message)
    {
        Console.WriteLine(message);
        await Task.CompletedTask;
    }
}