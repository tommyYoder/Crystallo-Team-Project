using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour {


    public AudioMixer volMixer;

    public AudioMixer sfxMixer;

    public Slider volSlider;
    public Slider sfxSlider;

    public Slider mouseSlider;
    public CameraController cameraController;
    

    public Dropdown qualityDropDown;

    public Dropdown resolutionDropdown;

    public Toggle fullScreenToggle;

    private int screenInt;

    Resolution[] resolutions;

    private bool isFullScreen = false;

    const string prefName = "optionvalue";
    const string resName = "resolutionoption";

    // Saves the vaules of quality, sets the toggle bool value to true or false, and resolution when the player clicks on the dropdowns.
    void Awake()
    {
        

        screenInt = PlayerPrefs.GetInt("togglestate");

        if(screenInt == 0)
        {          
            isFullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else
        {        
            fullScreenToggle.isOn = false;
        }

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropdown.value);
            PlayerPrefs.Save();
        }));
        qualityDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
            {
                PlayerPrefs.SetInt(prefName, qualityDropDown.value);
                PlayerPrefs.Save();
            }));
        }

    // Saves and gets the values of the volume slider, gets the int value of the quality value, and looks for a list of the resolution dropdown values and sets them based on the player's preference.
    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume", -40f);
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume", -40f));

        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", -40f);
        sfxMixer.SetFloat("fx", PlayerPrefs.GetFloat("SFXVolume", -40f));

        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensetivity", 15f);

        qualityDropDown.value = PlayerPrefs.GetInt(prefName, 2);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
       
    }

    // Will set the resolution based on the screen width of the player's monitor.
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        

    }

    // Updates Mouse Sensitivity slider based on the UI slider.
    public void SetMouse(float slider)
    {
        cameraController.ChangeMouseSensetivity(mouseSlider.value, mouseSlider.value);
        PlayerPrefs.SetFloat("MouseSensetivity", slider);
    }

    // Will change the value of the audio slider and set the int value to each level afterwards.
    public void ChangeVol(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));

    }

    // Will change the value of the sfx audio slider and set the int value to each level afterwards.
    public void ChangeFX(float fx)
    {
        PlayerPrefs.SetFloat("SFXVolume", fx);
        sfxMixer.SetFloat("fx", PlayerPrefs.GetFloat("SFXVolume"));
    }

    // Sets the quality of the game based on the int value indicated by the dropdown list.
    public void SetQuality(int qualityIndex)
    {
       
        QualitySettings.SetQualityLevel(qualityIndex);
        
       
    }

    // Will look to see if the player is fullscreen or not. If yes, then the toggle marker is on. If no, then the toggle marker is off.
    public void SetFullscreen(bool isFullScreen)
    {
      
        Screen.fullScreen = isFullScreen;

        if (isFullScreen == false)
        {
            PlayerPrefs.SetInt("togglestate", 1);
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt("togglestate", 0);
        }
    }
}

