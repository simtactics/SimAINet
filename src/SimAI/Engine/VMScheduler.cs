// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at
// http://mozilla.org/MPL/2.0/.
using SimAntics.Engine.Entities;

namespace SimAntics.Engine;

public class VMScheduler
{
    VM VM { get; set; }

    Dictionary<uint, List<VMEntity>> _tickScheduler = new();
    List<VMEntity> _tickThisFrame;

    public HashSet<VMEntity> PendingDeletion { get; set; } = new HashSet<VMEntity>();
    public uint CurrentTickID { get; set; }
    public short CurrentObjectID { get; set; }
    public bool RunningNow { get; set; }


    public VMScheduler(VM vm) => VM = vm;

    public void ScheduleTickIn(VMEntity _ent, uint delay)
    {

    }
}
