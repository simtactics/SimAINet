// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at
// http://mozilla.org/MPL/2.0/.
namespace SimAI.Marshals;

public class VMStackFrameMarshal
{
 public ushort RoutineID { get; set; }
 public ushort InstructionPointer { get; set; }
 public short Caller { get; set; }
 public short Callee { get; set; }
 public short StackObject { get; set; }
 public uint CodeOwnerGUID { get; set; }
 public short[] Locals { get; set; }
 public short[] Args { get; set; }
 public bool DiscardResult { get; set; }
 public bool ActionTree { get; set; }

 public int Version { get; set; }

 public VMStackFrameMarshal() { }
 public VMStackFrameMarshal(int version) { Version = version; }

 public virtual void Deserialize(BinaryReader reader)
 {
  RoutineID = reader.ReadUInt16();
  InstructionPointer = reader.ReadUInt16();
  Caller = reader.ReadInt16();
  Callee = reader.ReadInt16();
  StackObject = reader.ReadInt16();
  CodeOwnerGUID = reader.ReadUInt32();

  var localN = reader.ReadInt32();
  if (localN > -1)
  {
   Locals = new short[localN];
   for (var i = 0; i < localN; i++) Locals[i] = reader.ReadInt16();
  }

  var argsN = reader.ReadInt32();
  if (argsN > -1)
  {
   Args = new short[argsN];
   for (var i = 0; i < argsN; i++) Args[i] = reader.ReadInt16();
  }

  if (Version > 3) DiscardResult = reader.ReadBoolean();
  ActionTree = reader.ReadBoolean();
 }

 public virtual void SerializeInto(BinaryWriter writer)
 {
  writer.Write(RoutineID);
  writer.Write(InstructionPointer);
  writer.Write(Caller);
  writer.Write(Callee);
  writer.Write(StackObject);
  writer.Write(CodeOwnerGUID);
  writer.Write((Locals == null) ? -1 : Locals.Length);
  //if (Locals != null) writer.Write(VMSerializableUtils.ToByteArray(Locals));
  //writer.Write((Args == null) ? -1 : Args.Length);
  //if (Args != null) writer.Write(VMSerializableUtils.ToByteArray(Args));
  writer.Write(DiscardResult);
  writer.Write(ActionTree);
 }
}
