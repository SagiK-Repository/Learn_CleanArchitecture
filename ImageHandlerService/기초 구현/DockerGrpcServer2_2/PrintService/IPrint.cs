namespace DockerGrpcServer2_2.PrintService;

public interface IPrint
{
    public Task Print(string message);
}