using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public static bool isPaused;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void ResumeGame(){
        audioManager.PlaySFX(audioManager.unpause);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame(){
        audioManager.PlaySFX(audioManager.pause);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu(){
        audioManager.PlaySFX(audioManager.click);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        audioManager.PlaySFX(audioManager.click);
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OptionsMenu()
    {
        audioManager.PlaySFX(audioManager.click);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
