// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at
// http://mozilla.org/MPL/2.0/.
using System.Collections.Generic;

namespace SimAntics.Engine.Entities
{
    public class VMEntityRTTI
    {
        public string[] AttributeLabels;
    }

    public abstract class VMEntity
    {
        public static bool UseWorld = true;
        public VMEntityRTTI RTTI;
        public bool GhostImage;

        public short ObjectID;
        public uint PersistID;

        public short[] ObjectData;
        public LinkedList<short> MyList = new LinkedList<short>();
        // public List<VMSoundEntry> SoundThreads;

        // public VMRuntimeHeadline Headline;
        /// <summary>
        /// IS NOT serialized, but rather regenerated on deserialize.
        /// </summary>
        // public VMHeadlineRenderer HeadlineRenderer;

        // public GameObject Object;
        public VMThread Thread;
        // public VMMultitileGroup MultitileGroup;

        public short MainParam; //parameters passed to main on creation.
        public short MainStackOBJ;

        public VMEntity[] Contained = new VMEntity[0];
        public VMEntity Container;
        public short ContainerSlot;
        /// <summary>
        /// set when the entity is removed, threads owned by this object or with this object as callee will be cancelled/have their stack emptied
        /// </summary>
        public bool Dead;

        /** Relationship variables **/
        public Dictionary<ushort, List<short>> MeToObject;
        public Dictionary<uint, List<short>> MeToPersist;
        //a runtime cache for objects that have relationships to us. Used to get a quick reference to objects
        //that may need to delete a relationship to us.
        //note this can point to false positives, but the worst case is a slow deletion if somehow every object is added.
        public HashSet<ushort> MayHaveRelToMe = new HashSet<ushort>();

        //signals which relationships have changed since the last time this was reset
        //used to partial update relationships when doing an avatar save to db
        public HashSet<uint> ChangedRels = new HashSet<uint>();

        public ulong DynamicSpriteFlags; /** Used to show/hide dynamic sprites **/
        public ulong DynamicSpriteFlags2;
        //public VMObstacle Footprint;

        //LotTilePos _Position = new LotTilePos(LotTilePos.OUT_OF_WORLD);
        //public EntityComponent WorldUI;

        public uint TimestampLockoutCount = 0;
        //public Color LightColor = Color.White;

        //inferred properties (from object resource)
        //public GameGlobalResource SemiGlobal;
        //public TTAB TreeTable;
        //public TTAs TreeTableStrings;
        //public Dictionary<string, VMTreeByNameTableEntry> TreeByName;
        //public SLOT Slots;
        //public OBJD MasterDefinition; //if this object is multitile, its master definition will be stored here.
        //public OBJfFunctionEntry[] EntryPoints;  /** Entry points for specific events, eg. init, main, clean... **/
        //public virtual bool MovesOften
        //{
        //    get
        //    {
        //        if (Container != null) return true;
        //        if (Slots == null) return false;
        //        if (!Slots.Slots.ContainsKey(3)) return false;
        //        var slots = Slots.Slots[3];
        //        return (slots.Count > 7);
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        if (MultitileGroup.Name != "") return MultitileGroup.Name;
        //        else return this.ToString();
        //    }
        //    set
        //    {
        //        MultitileGroup.Name = value;
        //    }
        //}

        //bool DynamicMultitile
        //{
        //    get
        //    {
        //        return EntryPoints[8].ActionFunction >= 256;
        //    }
        //}

        //public override string ToString()
        //{
        //    if (MultitileGroup.Name != "") return MultitileGroup.Name;
        //    var strings = Object.Resource.Get<CTSS>(Object.OBJ.CatalogStringsID);
        //    if (strings != null)
        //    {
        //        return strings.GetString(0);
        //    }
        //    var label = Object.OBJ.ChunkLabel;
        //    if (label != null && label.Length > 0)
        //    {
        //        return label;
        //    }
        //    return Object.OBJ.GUID.ToString("X");
        //}

        //positioning properties

        protected static Direction[] DirectionNotches = new Direction[]
        {
            Direction.NORTH,
            Direction.NORTHEAST,
            Direction.EAST,
            Direction.SOUTHEAST,
            Direction.SOUTH,
            Direction.SOUTHWEST,
            Direction.WEST,
            Direction.NORTHWEST
        };

        //public LotTilePos Position
        //{
        //    get { return _Position; }
        //    set
        //    {
        //        _Position = value;
        //        if (UseWorld) WorldUI.Level = Position.Level;
        //        if (this is VMAvatar) ((VMAvatar)this).VisualPositionStart = null;
        //        VisualPosition = new Vector3(_Position.x / 16.0f, _Position.y / 16.0f, (_Position.Level - 1) * 2.95f);
        //    }
        // }

        // public abstract Vector3 VisualPosition { get; set; }
        public abstract Direction Direction { get; set; }
        public abstract float RadianDirection { get; set; }


    }
}
