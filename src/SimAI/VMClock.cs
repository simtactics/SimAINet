// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at
// http://mozilla.org/MPL/2.0/.

namespace SimAI;

public class VMClock
{
 public long Ticks { get; set; }
 public int MinuteFractions { get; set; }
 public int TicksPerMinute { get; set; }
 public int Minutes { get; set; }
 public int Hours { get; set; }

 public int DayOfMonth = 1;
 public int Month = 6;
 public int Year = 1997;

 public int FirePercent { get; set; }
 public long UTCStart = DateTime.UtcNow.Ticks;

 public int TimeOfDay => (Hours >= 6 && Hours < 18) ? 0 : 1;
 public int Seconds => MinuteFractions * 60 / TicksPerMinute;

 public DateTime UTCNow => new DateTime(UTCStart).AddSeconds(Ticks / 30.0);

 public VMClock() { }

 public void Tick()
 {
  if (FirePercent < 2000) FirePercent++;
  if (++MinuteFractions < TicksPerMinute) return;
  MinuteFractions = 0;
  if (++Minutes < 60) return;
  Minutes = 0;
  if (++DayOfMonth <= 30) return;
  DayOfMonth = 1;
  if (++Month <= 12) return;
  Month = 1;
  Year++;

  Ticks++;
 }
}