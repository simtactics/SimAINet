using System.Diagnostics;
using Xunit;

namespace SimAI.Tests;

public class VMClockTest
{
 [Fact]
 public void TickTest()
 {
  var clock = new VMClock();
  Debug.WriteLine(clock.Ticks);
  clock.Tick();
  Debug.WriteLine(clock.Ticks);
 }
}