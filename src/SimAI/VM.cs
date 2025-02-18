// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at
// http://mozilla.org/MPL/2.0/.
using SimAI;
using SimAntics.Engine;
using SimAntics.Engine.Entities;

namespace SimAntics;

/// <summary>
/// VM is an abstract class that contains the 
/// </summary>
public abstract class VM : IVM
{
    public bool IsTS1 { get; set; }
    public bool Ready { get; set; }
    public bool BHAVDirty { get; set; }
    public VMContext Context { get; internal set; }
    public VMScheduler Scheduler { set; get; }

    public delegate void VMRefreshHandler();
    public delegate void VMLotSwitchHandler(uint lotId);

    Dictionary<short, VMEntity> ObjectsById = new();
    short ObjectId = 1;

    public List<VMEntity> Entities = new();
    public HashSet<VMEntity> SoundEntities = new();
    public short[] GlobalState;

    int GameTickRate = 60;
    int GameTickNum = 0;
    public int SpeedMultiplier = 1;
    public int LastSpeedMultiplier;
    int LastFrameSpeed = 1;
    float Fraction;
    public VMEntity GlobalBlockingDialog;

    /// <summary>
    /// Gets an entity from this VM.
    /// </summary>
    /// <param name="id">The entity's ID.</param>
    /// <returns>A VMEntity instance associated with the ID.</returns>
    public VMEntity? GetObjectById(short id)
    {
        return ObjectsById.ContainsKey(id) ? ObjectsById[id] : null;
    }

    /// <summary>
    /// Constructs a new Virtual Machine instance.
    /// </summary>
    /// <param name="context">The VMContext instance to use.</param>
    public VM(VMContext context)
    {
        context.VM = this;
        Context = context;
        Scheduler = new VMScheduler(this);
    }

    public VMEntity GetObjectByPersist(uint id)
    {
        // return Entities.FirstOrDefault(x => x.PersistID == id);
        throw new VMSimanticsException();
    }

    public virtual void Init()
    {
        // PlatformState = (TS1)?(VMAbstractLotState)new VMTS1LotState():new VMTSOLotState();
        GlobalState = new short[38];
        GlobalState[20] = 255; //Game Edition. Basically, what "expansion packs" are running. Let's just say all of them.
        GlobalState[25] = 4; //as seen in EA-Land edith's simulator globals, this needs to be set for people to do their idle interactions.
        GlobalState[17] = 4; //Runtime Code Version, is this in EA-Land.
                             // if (Driver is VMServerDriver) EODHost = new VMEODHost();
    }

    public virtual void Reset()
    {
        throw new NotImplementedException();
    }
    public virtual void Update()
    {
        throw new NotImplementedException();
    }

    public virtual void Tick()
    {
        throw new NotImplementedException();
    }

    public virtual void InternalTick(uint tickId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds an entity to this Virtual Machine.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public void AddEntity(VMEntity entity)
    {
        entity.ObjectID = ObjectId;
        ObjectsById.Add(entity.ObjectID, entity);
        // AddToObjList(this.Entities, entity);
        // if (!entity.GhostImage) Context.ObjectQueries.NewObject(entity);
        // ObjectId = NextObjID();
    }

    public static void AddToObjList(List<VMEntity> list, VMEntity entity)
    {
        if (list.Count == 0) { list.Add(entity); return; }
        int id = entity.ObjectID;
        var max = list.Count;
        var min = 0;
        while (max > min)
        {
            var mid = (max + min) / 2;
            int nid = list[mid].ObjectID;
            if (id < nid) max = mid;
            else if (id == nid) return; //do not add dupes
            else min = mid + 1;
        }
        list.Insert(min, entity);
        // list.Insert((list[min].ObjectID>id)?min:((list[max].ObjectID > id)?max:max+1), entity);
    }

    /// <summary>
    /// Removes an entity from this Virtual Machine.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    public void RemoveEntity(VMEntity entity)
    {
        if (Entities.Contains(entity))
        {
            // Context.ObjectQueries.RemoveObject(entity);
            Entities.Remove(entity);
            ObjectsById.Remove(entity.ObjectID);
            // Scheduler.DescheduleTick(entity);
            if (entity.ObjectID < ObjectId) ObjectId = entity.ObjectID; //this id is now the smallest free object id.
        }
        entity.Dead = true;
    }
}