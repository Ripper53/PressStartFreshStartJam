using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuUI : MonoBehaviour {
    public GameObject Menu;
    public AudioMixer Mixer;

    public void Toggle() {
        Menu.SetActive(!Menu.activeSelf);
    }

    public void Open() {
        Menu.SetActive(true);
    }

    public void Close() {
        Menu.SetActive(false);
    }

    public void SetMasterVolume(float value) {
        SetVolume("MasterVolume", value);
    }

    public void SetMusicVolume(float value) {
        SetVolume("MusicVolume", value);
    }

    public void SetSFXVolume(float value) {
        SetVolume("SFXVolume", value);
    }

    private void SetVolume(string name, float value) {
        Mixer.SetFloat(name, value < 0.01f ? -80f : Mathf.Log10(value) * 20f);
    }

}
