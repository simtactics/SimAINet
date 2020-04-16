using System;
using System.Diagnostics;
using Xunit;

namespace SimAI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var clock = new VMClock();
            Console.WriteLine(clock.Ticks);
            clock.Tick();
            Console.WriteLine(clock.Ticks);
        }
    }
}