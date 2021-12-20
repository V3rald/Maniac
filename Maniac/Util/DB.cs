using Maniac.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Maniac.Util
{
    public class DB
    {
        public static DBModel readDB()
        {
            if(File.Exists("db.json")){
                return JsonConvert.DeserializeObject<DBModel>(File.ReadAllText("db.json"));
            }
            return new DBModel();
        }

        public static void addUser(ulong discordUserId, ulong osuUserId)
        {
            // TODO: Save user object instead of id
            DBModel db = readDB();

            db.Users.Add(new UserConnection(discordUserId, osuUserId));

            string json = JsonConvert.SerializeObject(db);
            File.WriteAllText("db.json", json);
        }

        public static ulong? getUser(ulong discordUserId)
        {
            DBModel db = readDB();
            foreach(UserConnection user in db.Users)
            {
                if(user.DiscorduserID == discordUserId)
                {
                    return user.OsuUserId;
                }
            }
            return null;
        }

        public static bool isUser(ulong osuUserId)
        {
            DBModel db = readDB();
            foreach (UserConnection user in db.Users)
            {
                if (user.OsuUserId == osuUserId)
                {
                    return true;
                }
            }
            return false;
        }

        public static LastBeatmap getLastBeatmap()
        {
            DBModel db = readDB();
            return db.LastBeatmap;
        }

        public static void setLastBeatmap(LastBeatmap beatmap)
        {
            DBModel db = readDB();
            db.LastBeatmap = beatmap;

            string json = JsonConvert.SerializeObject(db);
            File.WriteAllText("db.json", json);
        }
    }
}
