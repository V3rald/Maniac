﻿using Maniac.Model;
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
            DBModel db = readDB();

            db.Users.Add(new DBModel.User(discordUserId, osuUserId));

            string json = JsonConvert.SerializeObject(db);
            File.WriteAllText("db.json", json);
        }

        public static ulong? getUser(ulong discordUserId)
        {
            DBModel db = readDB();
            foreach(DBModel.User user in db.Users)
            {
                if(user.DiscorduserID == discordUserId)
                {
                    return user.OsuUserId;
                }
            }
            return null;
        }
    }
}
