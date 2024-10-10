namespace DockerDIService.PrintService;

public interface IPrint
{
    public Task Print(string message);
}