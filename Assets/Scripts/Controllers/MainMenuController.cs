using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void PlayGame(){
        audioManager.PlaySFX(audioManager.click);
        PauseMenu.isPaused = false;
        SceneManager.LoadScene("1Level");
    }

    public void QuitGame(){
        audioManager.PlaySFX(audioManager.click);
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OptionsMenu(){
        audioManager.PlaySFX(audioManager.click);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
