namespace Roller.Environment.Items.Pooling
{
    public interface IPoolable
    {
        bool IsActive { get; }
        void Deactivate();
        void Activate();
    }
}