namespace AvansDevOps.DevOps;

public class DevOpsAdapter : IDevops
{
    private DevOps _devops;

    public DevOpsAdapter()
    {
        this._devops = new DevOps();
    }
    
    public void Sources()
    {
        this._devops.Sources();
    }

    public void Package()
    {
        this._devops.Package();
    }

    public void Build()
    {
        this._devops.Build();
    }

    public void Test()
    {
        this._devops.Test();
    }

    public void Analysis()
    {
        this._devops.Analysis();
    }

    public void Deploy()
    {
        this._devops.Deploy();
    }

    public void Utility()
    {
        this._devops.Utility();
    }
}