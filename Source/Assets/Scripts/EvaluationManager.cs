using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationManager : MonoBehaviour
{
    public int mKnightCount;
    public int mArcherCount;
    public int mMageCount;
    public int mPaladinCount;
    public int mClericCount;
    public int mWarlockCount;

    public int mDefenderCount;
    public int mAttackerCount;
    public int mSpecialistCount;

    public string mKnightPercentageString;
    public string mArcherPercentageString;
    public string mMagePercentageString;
    public string mPaladinPercentageString;
    public string mClericPercentageString;
    public string mWarlockPercentageString;

    public string mDefenderPercentageString;
    public string mAttackerPercentageString;
    public string mSpecialistPercentageString;

    public TMPro.TextMeshProUGUI mDefenderText;
    public TMPro.TextMeshProUGUI mAttackerText;
    public TMPro.TextMeshProUGUI mSpecialistText;

    public TMPro.TextMeshProUGUI mKnightText;
    public TMPro.TextMeshProUGUI mArcherText;
    public TMPro.TextMeshProUGUI mMageText;
    public TMPro.TextMeshProUGUI mPaladinText;
    public TMPro.TextMeshProUGUI mClericText;
    public TMPro.TextMeshProUGUI mWarlockText;


    public void Awake()
    {
        mKnightCount = 0;
        mArcherCount = 0;
        mMageCount = 0;
        mPaladinCount = 0;
        mClericCount = 0;
        mWarlockCount = 0;
    }

    public void UpdateBalanceEvaluation(Team team)
    {
        List<KeyValuePair<string, int>> teamComp = team.GetTeamComposition();

        foreach (KeyValuePair<string, int> agent in teamComp)
        {
            switch (agent.Key)
            {
                case "knight":
                    mKnightCount++;
                    break;
                case "archer":
                    mArcherCount++;
                    break;
                case "mage":
                    mMageCount++;
                    break;
                case "paladin":
                    mPaladinCount++;
                    break;
                case "cleric":
                    mClericCount++;
                    break;
                case "warlock":
                    mWarlockCount++;
                    break;
            }
        }

        mDefenderCount = mKnightCount + mPaladinCount;
        mAttackerCount = mArcherCount + mMageCount;
        mSpecialistCount = mClericCount + mWarlockCount;

        int totalCharacterCount = mDefenderCount + mAttackerCount + mSpecialistCount;

        double knightPercentage = (double)mKnightCount / totalCharacterCount * 100;
        double archerPercentage = (double)mArcherCount / totalCharacterCount * 100;
        double magePercentage = (double)mMageCount / totalCharacterCount * 100;
        double paladinPercentage = (double)mPaladinCount / totalCharacterCount * 100;
        double clericPercentage = (double)mClericCount / totalCharacterCount * 100;
        double warlockPercentage = (double)mWarlockCount / totalCharacterCount * 100;

        mKnightPercentageString = knightPercentage.ToString("F2");
        mArcherPercentageString = archerPercentage.ToString("F2");
        mMagePercentageString = magePercentage.ToString("F2");
        mPaladinPercentageString = paladinPercentage.ToString("F2");
        mClericPercentageString = clericPercentage.ToString("F2");
        mWarlockPercentageString = warlockPercentage.ToString("F2");

        double defenderPercentage = (double)mDefenderCount / totalCharacterCount * 100;
        double attackerPercentage = (double)mAttackerCount / totalCharacterCount * 100;
        double specialistPercentage = (double)mSpecialistCount / totalCharacterCount * 100;

        mDefenderPercentageString = defenderPercentage.ToString("F2");
        mAttackerPercentageString = attackerPercentage.ToString("F2");
        mSpecialistPercentageString = specialistPercentage.ToString("F2");

        mDefenderText.text = mDefenderPercentageString;
        mAttackerText.text = mAttackerPercentageString;
        mSpecialistText.text = mSpecialistPercentageString;

        mKnightText.text = mKnightPercentageString;
        mArcherText.text = mArcherPercentageString;
        mMageText.text = mMagePercentageString;
        mPaladinText.text = mPaladinPercentageString;
        mClericText.text = mClericPercentageString;
        mWarlockText.text = mWarlockPercentageString;
    }

}
