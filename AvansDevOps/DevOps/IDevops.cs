namespace AvansDevOps.DevOps;

public interface IDevops
{
    void Sources();
    void Package();
    void Build();
    void Test();
    void Analysis();
    void Deploy();
    void Utility();
}