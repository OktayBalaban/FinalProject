using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class SettingsManager : MonoBehaviour
{
    //// Characters ////

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

    private SettingsData settings;

    [SerializeField] private InputField inputKnightHealth;
    [SerializeField] private InputField inputKnightDefense;

    [SerializeField] private InputField inputArcherHealth;
    [SerializeField] private InputField inputArcherDefense;
    [SerializeField] private InputField inputArcherOffense;

    [SerializeField] private InputField inputMageHealth;
    [SerializeField] private InputField inputMageDefense;
    [SerializeField] private InputField inputMageOffense;

    [SerializeField] private InputField inputHealerHealth;
    [SerializeField] private InputField inputHealerDefense;
    [SerializeField] private InputField inputHealerHealthBuff;

    [SerializeField] private InputField inputChanterHealth;
    [SerializeField] private InputField inputChanterDefense;
    [SerializeField] private InputField inputChanterDefenseBuff;
    [SerializeField] private InputField inputChanterOffenseBuff;

    [SerializeField] private InputField inputWarlockHealth;
    [SerializeField] private InputField inputWarlockDefense;
    [SerializeField] private InputField inputWarlockDefenseDebuff;

    public SettingsManager()
    {
        // To have a default values for the initial start of the program
        knightHealth = 350;
        knightDefense = 40;

        archerHealth = 70;
        archerDefense = 10;
        archerOffense = 150;

        mageHealth = 50;
        mageDefense = 10;
        mageOffense = 80;

        healerHealth = 40;
        healerDefense = 0;
        healerHealthBuff = 10;

        chanterHealth = 40;
        chanterDefense = 10;
        chanterDefenseBuff = 5;
        chanterOffenseBuff = 10;

        warlockHealth = 70;
        warlockDefense = 20;
        warlockDefenseDebuff = 30;
    }

    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "settings.json");
        if (!File.Exists(path))
        {
            SaveSettings();
        }

        loadData();
        populateInputFields();

    }


    public void SaveSettings()
    {
        string path = Path.Combine(Application.persistentDataPath, "settings.json");
        string jsonString = JsonUtility.ToJson(this);

        File.WriteAllText(path, jsonString);
        Debug.Log("Settings saved to " + path);

        loadData();
    }

    private void loadData()
    {
        settings = SettingsData.Instance;
        SettingsData.UpdateStats();

        knightHealth = settings.knightHealth;
        knightDefense = settings.knightDefense;

        archerHealth = settings.archerHealth;
        archerDefense = settings.archerDefense;
        archerOffense = settings.archerOffense;

        mageHealth = settings.mageHealth;
        mageDefense = settings.mageDefense;
        mageOffense = settings.mageOffense;

        healerHealth = settings.healerHealth;
        healerDefense = settings.healerDefense;
        healerHealthBuff = settings.healerHealthBuff;

        chanterHealth = settings.chanterHealth;
        chanterDefense = settings.chanterDefense;
        chanterDefenseBuff = settings.chanterDefenseBuff;
        chanterOffenseBuff = settings.chanterOffenseBuff;

        warlockHealth = settings.warlockHealth;
        warlockDefense = settings.warlockDefense;
        warlockDefenseDebuff = settings.warlockDefenseDebuff;
    }

    private void populateInputFields()
    {
        inputKnightHealth.text = knightHealth.ToString();
        inputKnightDefense.text = knightDefense.ToString();

        inputArcherHealth.text = archerHealth.ToString();
        inputArcherDefense.text = archerDefense.ToString();
        inputArcherOffense.text = archerOffense.ToString();

        inputMageHealth.text = mageHealth.ToString();
        inputMageDefense.text = mageDefense.ToString();
        inputMageOffense.text = mageOffense.ToString();

        inputHealerHealth.text = healerHealth.ToString();
        inputHealerDefense.text = healerDefense.ToString();
        inputHealerHealthBuff.text = healerHealthBuff.ToString();

        inputChanterHealth.text = chanterHealth.ToString();
        inputChanterDefense.text = chanterDefense.ToString();
        inputChanterDefenseBuff.text = chanterDefenseBuff.ToString();
        inputChanterOffenseBuff.text = chanterOffenseBuff.ToString();

        inputWarlockHealth.text = warlockHealth.ToString();
        inputWarlockDefense.text = warlockDefense.ToString();
        inputWarlockDefenseDebuff.text = warlockDefenseDebuff.ToString();
    }


    public void ChangeKnightHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            Debug.Log("Knight Health Changed: " + value);
            knightHealth = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeKnightDefense(string defense) 
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            Debug.Log("Knight Defense Changed: " + value);
            knightDefense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeArcherHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            Debug.Log("Archer Health Changed: " + value);
            archerHealth = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeArcherDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            Debug.Log("Archer Defense Changed: " + value);
            archerDefense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeArcherOffense(string offense)
    {
        int value;
        if (int.TryParse(offense, out value))
        {
            Debug.Log("Archer Offense Changed: " + value);
            archerOffense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }



    public void ChangeMageHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            Debug.Log("Mage Health Changed: " + value);
            mageHealth = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeMageDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            Debug.Log("Mage Defense Changed: " + value);
            mageDefense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeMageOffense(string offense)
    {
        int value;
        if (int.TryParse(offense, out value))
        {
            Debug.Log("Mage Offense Changed: " + value);
            mageOffense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }



    public void ChangeHealerHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            Debug.Log("Healer Health Changed: " + value);
            healerHealth = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeHealerDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            Debug.Log("Healer Defense Changed: " + value);
            healerDefense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeHealerHealthBuff(string healthBuff)
    {
        int value;
        if (int.TryParse(healthBuff, out value))
        {
            Debug.Log("Healer Health buff Changed: " + value);
            healerHealthBuff = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }



    public void ChangeChanterHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            Debug.Log("Chanter Health Changed: " + value);
            chanterHealth = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeChanterDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            Debug.Log("Chanter Defense Changed: " + value);
            chanterDefense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeChanterDefenseBuff(string defenseBuff)
    {
        int value;
        if (int.TryParse(defenseBuff, out value))
        {
            Debug.Log("Chanter Defense buff Changed: " + value);
            chanterDefenseBuff = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeChanterOffenseBuff(string offenseBuff)
    {
        int value;
        if (int.TryParse(offenseBuff, out value))
        {
            Debug.Log("Chanter Offense buff Changed: " + value);
            chanterOffenseBuff = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }



    public void ChangeWarlockHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            Debug.Log("Warlock Health Changed: " + value);
            warlockHealth = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeWarlockDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            Debug.Log("Warlock Defense Changed: " + value);
            warlockDefense = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }

    public void ChangeWarlockDefenseDebuff(string defenseDebuff)
    {
        int value;
        if (int.TryParse(defenseDebuff, out value))
        {
            Debug.Log("Warlock Defense Debuff Changed: " + value);
            warlockDefenseDebuff = value;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
        }
    }
}
