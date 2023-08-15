using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class SettingsManager : MonoBehaviour
{

    private SettingsData settings;

    //// Characters ////

    public int knightHealth;
    public int knightDefense;

    public int archerHealth;
    public int archerDefense;
    public int archerOffense;

    public int mageHealth;
    public int mageDefense;
    public int mageOffense;

    public int paladinHealth;
    public int paladinDefense;
    public int paladinHealthBuff;

    public int clericHealth;
    public int clericDefense;
    public int clericDefenseBuff;
    public int clericOffenseBuff;

    public int warlockHealth;
    public int warlockDefense;
    public int warlockDefenseDebuff;

    // Game Settings

    public int roundLimit;
    public int turnLimit;
    public int teamSize;
    public int numberOfTeams;

    // Evolution Settings

    public int numberOfCrossbreedParents;
    public int numberOfCrossbreedReplacements;
    public float mutationCoefficient;
    public float mutationBias;


    [SerializeField] private InputField inputKnightHealth;
    [SerializeField] private InputField inputKnightDefense;

    [SerializeField] private InputField inputArcherHealth;
    [SerializeField] private InputField inputArcherDefense;
    [SerializeField] private InputField inputArcherOffense;

    [SerializeField] private InputField inputMageHealth;
    [SerializeField] private InputField inputMageDefense;
    [SerializeField] private InputField inputMageOffense;

    [SerializeField] private InputField inputPaladinHealth;
    [SerializeField] private InputField inputPaladinDefense;
    [SerializeField] private InputField inputPaladinHealthBuff;

    [SerializeField] private InputField inputClericHealth;
    [SerializeField] private InputField inputClericDefense;
    [SerializeField] private InputField inputClericDefenseBuff;
    [SerializeField] private InputField inputClericOffenseBuff;

    [SerializeField] private InputField inputWarlockHealth;
    [SerializeField] private InputField inputWarlockDefense;
    [SerializeField] private InputField inputWarlockDefenseDebuff;

    [SerializeField] private InputField inputRoundLimit;
    [SerializeField] private InputField inputTurnLimit;
    [SerializeField] private InputField inputTeamSize;
    [SerializeField] private InputField inputNumberOfTeams;


    [SerializeField] private InputField inputNumberOfCrossbreedParents;
    [SerializeField] private InputField inputNumberOfCrossbreedReplacements;
    [SerializeField] private InputField inputMutationCoefficient;
    [SerializeField] private InputField inputMutationBias;

    private bool mIsAllValid;


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

        paladinHealth = 40;
        paladinDefense = 0;
        paladinHealthBuff = 10;

        clericHealth = 40;
        clericDefense = 10;
        clericDefenseBuff = 5;
        clericOffenseBuff = 10;

        warlockHealth = 70;
        warlockDefense = 20;
        warlockDefenseDebuff = 30;

        roundLimit = 1000;
        turnLimit = 40;
        teamSize = 10;
        numberOfTeams = 20;

        numberOfCrossbreedParents = 5;
        numberOfCrossbreedReplacements = 2;
        mutationCoefficient = 0.05f;
        mutationBias = 0.0000f;

        mIsAllValid = true;

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

        paladinHealth = settings.paladinHealth;
        paladinDefense = settings.paladinDefense;
        paladinHealthBuff = settings.paladinHealthBuff;

        clericHealth = settings.clericHealth;
        clericDefense = settings.clericDefense;
        clericDefenseBuff = settings.clericDefenseBuff;
        clericOffenseBuff = settings.clericOffenseBuff;

        warlockHealth = settings.warlockHealth;
        warlockDefense = settings.warlockDefense;
        warlockDefenseDebuff = settings.warlockDefenseDebuff;

        roundLimit = settings.roundLimit;
        turnLimit = settings.turnLimit;
        teamSize = settings.teamSize;
        numberOfTeams = settings.numberOfTeams;

        numberOfCrossbreedParents = settings.numberOfCrossbreedParents;
        numberOfCrossbreedReplacements = settings.numberOfCrossbreedReplacements;
        mutationCoefficient = settings.mutationCoefficient;
        mutationBias = settings.mutationBias;
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

        inputPaladinHealth.text = paladinHealth.ToString();
        inputPaladinDefense.text = paladinDefense.ToString();
        inputPaladinHealthBuff.text = paladinHealthBuff.ToString();

        inputClericHealth.text = clericHealth.ToString();
        inputClericDefense.text = clericDefense.ToString();
        inputClericDefenseBuff.text = clericDefenseBuff.ToString();
        inputClericOffenseBuff.text = clericOffenseBuff.ToString();

        inputWarlockHealth.text = warlockHealth.ToString();
        inputWarlockDefense.text = warlockDefense.ToString();
        inputWarlockDefenseDebuff.text = warlockDefenseDebuff.ToString();

        inputRoundLimit.text = roundLimit.ToString();
        inputTurnLimit.text = turnLimit.ToString();
        inputTeamSize.text = teamSize.ToString();
        inputNumberOfTeams.text = numberOfTeams.ToString();

        inputNumberOfCrossbreedParents.text = numberOfCrossbreedParents.ToString();
        inputNumberOfCrossbreedReplacements.text = numberOfCrossbreedReplacements.ToString();
        inputMutationCoefficient.text = mutationCoefficient.ToString();
        inputMutationBias.text = mutationBias.ToString();
    }

    public bool CheckInputs()
    {
        return mIsAllValid;
    }

    public void ChangeKnightHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Knight Health Changed: " + value);
            knightHealth = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeKnightDefense(string defense) 
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999) 
            {
                value = 9999;
            }
            Debug.Log("Knight Defense Changed: " + value);
            knightDefense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeArcherHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Archer Health Changed: " + value);
            archerHealth = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeArcherDefense(string defense)
    {
        int value;

        if (int.TryParse(defense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Archer Defense Changed: " + value);
            archerDefense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }
        
        populateInputFields();

    }

    public void ChangeArcherOffense(string offense)
    {
        int value;
        if (int.TryParse(offense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Archer Offense Changed: " + value);
            archerOffense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }



    public void ChangeMageHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Mage Health Changed: " + value);
            mageHealth = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeMageDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Mage Defense Changed: " + value);
            mageDefense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeMageOffense(string offense)
    {
        int value;
        if (int.TryParse(offense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Mage Offense Changed: " + value);
            mageOffense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }



    public void ChangePaladinHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Paladin Health Changed: " + value);
            paladinHealth = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangePaladinDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Paladin Defense Changed: " + value);
            paladinDefense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangePaladinHealthBuff(string healthBuff)
    {
        int value;
        if (int.TryParse(healthBuff, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Paladin Health buff Changed: " + value);
            paladinHealthBuff = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }



    public void ChangeClericHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Cleric Health Changed: " + value);
            clericHealth = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeClericDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Cleric Defense Changed: " + value);
            clericDefense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeClericDefenseBuff(string defenseBuff)
    {
        int value;
        if (int.TryParse(defenseBuff, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Cleric Defense buff Changed: " + value);
            clericDefenseBuff = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeClericOffenseBuff(string offenseBuff)
    {
        int value;
        if (int.TryParse(offenseBuff, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Cleric Offense buff Changed: " + value);
            clericOffenseBuff = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }



    public void ChangeWarlockHealth(string health)
    {
        int value;
        if (int.TryParse(health, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Warlock Health Changed: " + value);
            warlockHealth = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeWarlockDefense(string defense)
    {
        int value;
        if (int.TryParse(defense, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Warlock Defense Changed: " + value);
            warlockDefense = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeWarlockDefenseDebuff(string defenseDebuff)
    {
        int value;
        if (int.TryParse(defenseDebuff, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9999)
            {
                value = 9999;
            }
            Debug.Log("Warlock Defense Debuff Changed: " + value);
            warlockDefenseDebuff = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeRoundLimit(string limit)
    {
        int value;
        if (int.TryParse(limit, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 100000)
            {
                value = 100000;
            }
            Debug.Log("Round Limit Changed: " + value);
            roundLimit = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeTurnLimit(string limit)
    {
        int value;
        if (int.TryParse(limit, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 1000)
            {
                value = 1000;
            }
            Debug.Log("Turn Limit Changed: " + value);
            turnLimit = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeTeamSize(string size)
    {
        int value;
        if (int.TryParse(size, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 50)
            {
                value = 50;
            }
            Debug.Log("Team Size Changed: " + value);
            teamSize = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        // Need to check Crossbreed Numbers
        if (numberOfCrossbreedParents > teamSize)
        {
            ChangeNumberOfCrossbreedParents(teamSize.ToString());
        }
        if (numberOfCrossbreedReplacements > teamSize)
        {
            ChangeNumberOfCrossbreedReplacements(teamSize.ToString());
        }

        populateInputFields();
    }

    public void ChangeNumberOfTeams(string number)
    {
        int value;
        if (int.TryParse(number, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 50)
            {
                value = 50;
            }
            Debug.Log("Number of Teams Changed: " + value);
            numberOfTeams = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }
        populateInputFields();
    }

    public void ChangeNumberOfCrossbreedParents(string number)
    {
        int value;
        if (int.TryParse(number, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > teamSize)
            {
                value = teamSize;
            }
            Debug.Log("Number of Crossbreed Parents Changed: " + value);
            numberOfCrossbreedParents = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeNumberOfCrossbreedReplacements(string number)
    {
        int value;
        if (int.TryParse(number, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > teamSize)
            {
                value = teamSize;
            }
            Debug.Log("Number of Crossbreed Replacements Changed: " + value);
            numberOfCrossbreedReplacements = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter an Integer Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }
    public void ChangeMutationCoefficient(string number)
    {
        float value;

        try
        {
            number = number.Replace('.', ',');
        }
        catch
        {
            Debug.LogError("Invalid input, please enter a Float Value!");
        }

        if (float.TryParse(number, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 0.9999f)
            {
                value = 0.9999f;
            }
            Debug.Log("Mutation Ceefficient Changed: " + value);
            mutationCoefficient = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter a Float Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

    public void ChangeMutationBias(string number)
    {
        float value;

        try
        {
            number = number.Replace('.', ',');
        }
        catch
        {
            Debug.LogError("Invalid input, please enter a Float Value!");
        }

        if (float.TryParse(number, out value))
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 0.9999f)
            {
                value = 0.9999f;
            }
            Debug.Log("Mutation Bias Changed: " + value);
            mutationBias = value;
            mIsAllValid = true;
        }
        else
        {
            Debug.LogError("Invalid input, please enter a Float Value!");
            mIsAllValid = false;
        }

        populateInputFields();
    }

}
