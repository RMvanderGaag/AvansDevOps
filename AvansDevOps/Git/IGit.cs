namespace AvansDevOps;

public interface IGit
{
    void Commit(IGitItem item);
    void Push();
    void Pull();
    void Merge();
    void Branch();
}