using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer SFX;
    public AudioMixer Music;
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Dropdown Qualty;
    public Dropdown language;
    public Toggle vsync;
    private void Start()
    {
        SFX.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        Music.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
        MusicSlider.value = PlayerPrefs.GetFloat("Music");
        Qualty.value = QualitySettings.GetQualityLevel();
        Debug.Log(PlayerPrefs.GetFloat("SFX"));
        language.value = PlayerPrefs.GetInt("language") - 1;

        Qualtytxt[2].StringChanged += UpdateDropdownHigh;
        Qualtytxt[1].StringChanged += UpdateDropdownMedium;
        Qualtytxt[0].StringChanged += UpdateDropdownLow;

        foreach(LocalizedString localized in Qualtytxt)
        {
            Qualty.options[localized.Count].text = Qualtytxt[localized.Count].GetLocalizedString();
        }

    }

    public void setSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFX", volume);
        SFX.SetFloat("SFX", volume);
        Debug.Log(volume);
    }
    public void setMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("Music", volume);
        Music.SetFloat("Music", volume);
        Debug.Log(volume);
    }
    public void SetQualty(int QualtyIndex) => QualitySettings.SetQualityLevel(QualtyIndex);
   // public void vsync(bool sync) => 
   public void clearedData()
   {
        PlayerPrefs.DeleteAll();
   }

    public void ChangeJoy(int value)
    {
        JoystickType joystick = JoystickType.Fixed;
        if (value == 0) joystick = JoystickType.Fixed;
        if (value == 1) joystick = JoystickType.Dynamic;
        if (value == 2) joystick = JoystickType.Floating;
        VariableJoystick.joystickType = joystick;
        VariableJoystick.OnChange.Invoke();
    }
    #region Localization
    private bool canChangeLocal = false;


    public void ChangeLocal(int id)
    {
        if (canChangeLocal) return;
        StartCoroutine(SetLocal(id));
    }

    IEnumerator SetLocal(int localId)
    {
        canChangeLocal = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localId];
        PlayerPrefs.SetInt("language", localId + 1);
        canChangeLocal = false;
        foreach(LocalizedString @string in Qualtytxt) @string.RefreshString();


        QualtyLabel.text = Qualtytxt[Qualty.value].GetLocalizedString();
    }

    public LocalizedString[] Qualtytxt;
    public Text QualtyLabel;

    private void UpdateDropdownHigh(string value)
    {
        Qualty.options[2].text = value;
    }
    private void UpdateDropdownMedium(string value)
    {
        Qualty.options[1].text = value;
    }
    private void UpdateDropdownLow(string value)
    {
        Qualty.options[0].text = value;
    }
    #endregion
}
