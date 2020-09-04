public interface ITrigger
{
    void Add(Triggerable addedTrigger);
    void Remove(Triggerable removedTrigger);
    void Notify();
}
