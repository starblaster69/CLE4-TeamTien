using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource BackgroundMusic;

    void Start(){
        BackgroundMusic.ignoreListenerPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause=false;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        AudioListener.pause=true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        AudioListener.pause=false;
        SceneManager.LoadScene("MainMenuRace");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
