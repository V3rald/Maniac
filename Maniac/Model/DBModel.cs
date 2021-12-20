using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model
{
    public class DBModel
    {
        public List<UserConnection> Users { get; set; }
        public LastBeatmap LastBeatmap { get; set; }

        public DBModel()
        {
            Users = new List<UserConnection>();
        }
    }

    public class LastBeatmap
    {
        public long BeatmapId { get; set; }
        public List<string> Mods { get; set; }

        public LastBeatmap(long beatmapId, List<string> mods)
        {
            BeatmapId = beatmapId;
            Mods = mods;
        }
    }

    public class UserConnection
    {
        public ulong DiscorduserID { get; set; }
        public ulong OsuUserId { get; set; }

        public UserConnection(ulong discorduserID, ulong osuUserId)
        {
            DiscorduserID = discorduserID;
            OsuUserId = osuUserId;
        }
    }
}
