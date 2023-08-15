using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public Transform mSettingManagerObj;
    private SettingsManager mSettingsManager;

    public GameObject mSettingsPanel;
    public GameObject mMainMenuPanel;

    public TMPro.TextMeshProUGUI mTitleText;

    public void Awake()
    {
        mSettingsPanel = transform.Find("SettingsPanel").gameObject;
        mSettingsManager = mSettingsPanel.GetComponent<SettingsManager>();

        mMainMenuPanel = transform.Find("MainMenu").gameObject;
    }

    public void Start()
    {
        mSettingsPanel.SetActive(false);
        mMainMenuPanel.SetActive(true);
    }

    public void StartSim()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenSettingsMenu()
    {
        mSettingsPanel.SetActive(true);
        mMainMenuPanel.SetActive(false);
    }

    public void SaveAndReturn()
    {
        if (mSettingsManager.CheckInputs()) 
        {
            mSettingsManager.SaveSettings();

            mSettingsPanel.SetActive(false);
            mMainMenuPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
