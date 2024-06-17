using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    AudioManager audioManager;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject pauseMenu;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start(){
        if (PlayerPrefs.HasKey("Volume")){
            LoadVolume();
        }
        else{
            setVolume();
            setMusic();
        }
    }
    public void setVolume (){
        float volume = volumeSlider.value;
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    private void LoadVolume(){
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        sfxSlider.value = PlayerPrefs.GetFloat("Sfx");
        setVolume();
        setMusic();
        setSFX();
    }

    public void setMusic(){
        float music = musicSlider.value;
        audioMixer.SetFloat("music", music);
        PlayerPrefs.SetFloat("Music", music);
    }

    public void setSFX()
    {
        float sfx = sfxSlider.value;
        audioMixer.SetFloat("sfx", sfx);
        PlayerPrefs.SetFloat("Sfx", sfx);
    }

    public void MainMenu()
    {
        audioManager.PlaySFX(audioManager.click);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void PauseMenu()
    {
        audioManager.PlaySFX(audioManager.click);
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
