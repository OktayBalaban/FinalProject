using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class SettingsData
{
    public int knightHealth;
    public int knightDefense;

    public int archerHealth;
    public int archerDefense;
    public int archerOffense;

    public int mageHealth;
    public int mageDefense;
    public int mageOffense;

    public int healerHealth;
    public int healerDefense;
    public int healerHealthBuff;

    public int chanterHealth;
    public int chanterDefense;
    public int chanterDefenseBuff;
    public int chanterOffenseBuff;

    public int warlockHealth;
    public int warlockDefense;
    public int warlockDefenseDebuff;

    private static SettingsData instance;

    public static SettingsData Instance
    {
        get
        {
            if (instance == null)
            {
                string path = Path.Combine(Application.persistentDataPath, "settings.json");
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    instance = JsonUtility.FromJson<SettingsData>(jsonString);
                }
                else
                {
                    instance = new SettingsData();
                }
            }
            return instance;
        }
    }

    public static void UpdateStats()
    {
        string path = Path.Combine(Application.persistentDataPath, "settings.json");
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            instance = JsonUtility.FromJson<SettingsData>(jsonString);
        }
    }
}

