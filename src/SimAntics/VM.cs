using System;

namespace SimAntics
{
    /// <summary>
    /// VM is an abstract class that contains the 
    /// </summary>
    public abstract class VM : IVM
    {
        public bool IsTS1 { get; set; }
        public bool Ready { get; set; }
        public bool BHAVDirty { get; set; }

        public delegate void VMRefreshHandler();
        public delegate void VMLotSwitchHandler(uint lotId);

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public void InternalTick(uint tickId)
        {
            throw new NotImplementedException();
        }
    }
}