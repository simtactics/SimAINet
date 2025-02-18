// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at
// http://mozilla.org/MPL/2.0/.
#if !Server
#define IDE_COMPAT
#endif

namespace SimAntics.Engine;

/// <summary>
/// Compatibility class 
/// </summary>
public class VMThread : VMInstruction { }

/// <summary>
/// Handles instruction sets
/// </summary>
public class VMInstruction
{
    public static int MAX_USER_ACTIONS = 20;

    public VMContext? Context;

    //check tree only vars
    public bool IsCheck;

    VMEntity? Entity;

    public List<VMStackFrame>? Stack;
    bool ContinueExecution;

    public string? ThreadBreakString;
    public int BreakFrame; //frame the last breakpoint was performed on
    public bool RoutineDirty;

    public bool Interrupt;

    ushort ActionUID;

    // Exception handling variables
    // Don't need to be serialized.
    public int DialogCooldown = 0;
    // the number of ticks that have executed so far this frame. If this exceeds the allowed max,
    // the thread resets, and a SimAI Error pops up.
    public int TicksThisFrame = 0;
    // the maximum number of primitives a thread can execute in one frame. Tweak appropriately.

    // variables for internal scheduler
    public uint ScheduleIdleStart; // keep track of tick when we started idling for an object. must be synced!
    public uint ScheduleIdleEnd;

}