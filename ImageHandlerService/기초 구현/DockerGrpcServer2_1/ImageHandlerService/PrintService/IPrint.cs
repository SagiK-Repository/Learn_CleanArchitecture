namespace DockerGrpcServer2_1.PrintService;

public interface IPrint
{
    public Task Print(string message);
}