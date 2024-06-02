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
        setVolume();
        setMusic();
    }

    public void setMusic(){
        float music = musicSlider.value;
        audioMixer.SetFloat("music", music);
        PlayerPrefs.SetFloat("Music", music);
    }
}
