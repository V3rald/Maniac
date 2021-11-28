using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model
{
    public class DBModel
    {
        public List<User> Users { get; set; }

        public class User
        {
            public ulong DiscorduserID { get; set; }
            public ulong OsuUserId { get; set; }

            public User(ulong discorduserID, ulong osuUserId)
            {
                DiscorduserID = discorduserID;
                OsuUserId = osuUserId;
            }
        }

        public DBModel()
        {
            Users = new List<User>();
        }
    }
}
