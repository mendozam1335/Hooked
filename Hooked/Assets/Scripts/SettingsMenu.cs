/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle the interactions in the settings menu including, changing volume, resolution,
 *  full screen and graphics
 * GameObjects associated: Settings Menu UI 
 * Files Associated: 
 * Source:
 *--------------------------------*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private Resolution[] resolution;
    public TMP_Dropdown resolutionDropdown;
    private void Start()
    {
        int i = 0;
        resolution = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        foreach (var res  in resolution)
        {
            string option = res.width + " x " + res.height;
            options.Add(option);
            if (res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

            i++;
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolution[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void setVolume(float volume)
    {
        Debug.Log(volume);
        if (volume == 0f)
        {
            audioMixer.SetFloat("Volume", float.Epsilon);
        }
        else
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20f);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
