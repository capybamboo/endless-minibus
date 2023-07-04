using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string> ();
        resolutions = Screen.resolutions;

        int currentResolutionIndex = 0;
        int i = 0;
        string option;


        foreach (Resolution resolution in resolutions) 
        {
            option = resolution.width + "x" + resolution.height + " " + Convert.ToString(Math.Round(resolution.refreshRateRatio.value)) + "Hz";
            options.Add(option);
            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
            i++;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.value = currentResolutionIndex;

    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetvSync(bool isvSync)
    {
        QualitySettings.vSyncCount = isvSync ? 1 : 0;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ExitSettings()
    {
        Debug.Log("going to main menu");
        CutsceneManager.Instance.StartCutscene("to_main_menu");
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("vSyncPreference", QualitySettings.vSyncCount);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
        }
        
        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        }
        else 
        { 
            Screen.fullScreen = true; 
        }

        if (PlayerPrefs.HasKey("vSyncPreference"))
        {
            QualitySettings.vSyncCount = PlayerPrefs.GetInt("vSyncPreference");
        }
        else 
        {
            QualitySettings.vSyncCount = 0; 
        }

    }
}
