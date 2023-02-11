using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class RaceGroup
    {
        public RaceGroup(string groupName, int startTime, int blockStart, int blockEnd)
        {
            this.GroupName = groupName;
            this.StartTime = startTime;
            this.BlockStart = blockStart;
            this.BlockEnd = blockEnd;
        }

        public static RaceGroup parseRaceGroup(string[] fields)
        {
            return new RaceGroup(
                fields[1],
                Int32.Parse(fields[2]),
                Int32.Parse(fields[3]),
                Int32.Parse(fields[4])
                );
        }

        public string GroupName { get; set; }
        public int StartTime { get; set; }
        public int BlockStart { get; set; }
        public int BlockEnd { get; set; }
    }
}
