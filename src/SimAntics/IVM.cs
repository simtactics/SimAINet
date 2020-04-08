namespace SimAntics
{
    public interface IVM
    {
        void Init();
        void Reset();
        void Update();
        void Tick();
        void InternalTick(uint tickId);
    }
}
