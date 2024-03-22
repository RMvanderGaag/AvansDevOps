using AvansDevOps.DevOps;

namespace AvansDevOps;

public class Pipeline
{
    private readonly DevOpsAdapter _devOpsAdapter;
    
    public Pipeline()
    {
        _devOpsAdapter = new DevOpsAdapter();
    }
    
    public bool Execute(bool failing)
    {
        _devOpsAdapter.Sources();
        _devOpsAdapter.Package();
        _devOpsAdapter.Build();
        if (failing)
        {
            Console.WriteLine("Pipeline failed. Try again!");
            return false;
        }
        _devOpsAdapter.Test();
        _devOpsAdapter.Analysis();
        _devOpsAdapter.Deploy();
        _devOpsAdapter.Utility();
        Console.WriteLine("Pipeline has been completed.");
        return true;
    }
}