namespace AvansDevOps;

public class GitAdapter : IGit
{
    private Git _git;
    
    public GitAdapter()
    {
        this._git = new Git();
    }
    
    public void Commit(IGitItem backlogItem)
    {
        this._git.Commit(backlogItem);
    }

    public void Push()
    {
        this._git.Push();
    }

    public void Pull()
    {
        this._git.Pull();
    }

    public void Merge()
    {
        this._git.Merge();
    }

    public void Branch()
    {
        this._git.Branch();
    }
}