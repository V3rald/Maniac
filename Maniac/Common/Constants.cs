using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Common
{
    public class Constants
    {
        public enum Mods
        {
            NM,
            HD,
            FL,
            DT,
            NC,
        }

        public enum Mode
        {
            Fruits,
            Mania,
            Osu,
            Taiko
        }

        public enum Status
        {
            Ranked,
            Loved,
            Graveyard,
            Pending,
            Approved,
            Qualified,
            Wip,
            Any
        }
    }
}
