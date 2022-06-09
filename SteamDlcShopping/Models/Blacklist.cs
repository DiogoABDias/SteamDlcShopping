﻿using Newtonsoft.Json;

namespace SteamDlcShopping.Models
{
    internal class Blacklist
    {
        //Properties
        internal List<GameBlacklist>? Games { get; private set; }

        //Methods
        internal void Load()
        {
            if (!File.Exists("blacklist.txt"))
            {
                return;
            }

            string content = File.ReadAllText("blacklist.txt");
            Games = JsonConvert.DeserializeObject<List<GameBlacklist>>(content);
        }

        internal void Save()
        {
            if (Games is not null)
            {
                return;
            }

            string content = JsonConvert.SerializeObject(Games);
            File.WriteAllText("blacklist.txt", content);
        }

        internal void AddGame(int appId, string name, bool autoBlacklisted = true)
        {
            if (Games is null)
            {
                Games = new();
            }

            GameBlacklist gameBlacklist = new()
            {
                AppId = appId,
                Name = name,
                AutoBlacklisted = autoBlacklisted
            };

            Games.Add(gameBlacklist);
        }

        internal void RemoveGame(int appId)
        {
            if (Games is null)
            {
                return;
            }

            if (!Games.Any(x => x.AppId == appId))
            {
                return;
            }

            int index = Games.FindIndex(x => x.AppId == appId);
            Games.RemoveAt(index);
        }
    }
}