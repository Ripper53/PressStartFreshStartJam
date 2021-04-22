using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SettingsMenuUI : MonoBehaviour {
    public GameObject Menu;
    public AudioMixer Mixer;

    private static float masterVolume = 1f, musicVolume = 1f, sfxVolume = 1f;

    public Slider MasterVolumeSlider, MusicVolumeSlider, SFXVolumeSlider;
    public Toggle FullScreenToggle;
    public TMP_Dropdown ResolutionDropdown;

    private Resolution[] resolutions;

    private void Awake() {
        MasterVolumeSlider.value = masterVolume;
        MusicVolumeSlider.value = musicVolume;
        SFXVolumeSlider.value = sfxVolume;
        FullScreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);
        FullScreenToggle.onValueChanged.AddListener(SetFullScreen);

        resolutions = Screen.resolutions;

        List<string> ops = new List<string>(resolutions.Length);
        int currentIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            Resolution r = resolutions[i];
            ops.Add($"{r.width}x{r.height}");
            if (r.width == Screen.width && r.height == Screen.height)
                currentIndex = i;
        }
        ResolutionDropdown.AddOptions(ops);
        ResolutionDropdown.RefreshShownValue();
        ResolutionDropdown.SetValueWithoutNotify(currentIndex);

        ResolutionDropdown.onValueChanged.AddListener(SetResolution);
    }
    private void SetResolution(int index) {
        Resolution r = resolutions[index];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void Toggle() {
        if (Menu.activeSelf)
            Close();
        else
            Open();
    }

    public void Open() {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Close() {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void SetFullScreen(bool value) {
        Screen.fullScreen = value;
    }

    private const string masterVolumeName = "MasterVolume";
    public void SetMasterVolume(float value) {
        masterVolume = value;
        SetVolume(masterVolumeName, value);
    }

    private const string musicVolumeName = "MusicVolume";
    public void SetMusicVolume(float value) {
        musicVolume = value;
        SetVolume(musicVolumeName, value);
    }

    private const string sfxVolumeName = "SFXVolume";
    public void SetSFXVolume(float value) {
        sfxVolume = value;
        SetVolume(sfxVolumeName, value);
    }

    private void SetVolume(string name, float value) {
        Mixer.SetFloat(name, value < 0.01f ? -80f : Mathf.Log10(value) * 20f);
    }

}
