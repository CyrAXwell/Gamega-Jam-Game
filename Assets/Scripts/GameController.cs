using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Image scoreBackground;
    private bool isGameOver = false;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] AudioSource gameOverSound;

    void Start()
    {
        Time.timeScale = 1f;
        StateNameController.isPaused = false; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if(StateNameController.isPaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        scoreBackground.enabled = true;
        Time.timeScale = 1f;
        StateNameController.isPaused = false; 
        
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        scoreBackground.enabled = false;
        Time.timeScale = 0f;
        StateNameController.isPaused = true; 
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        Resume();
        SceneManager.LoadScene(2);
    }

    public void GameOverRetry()
    {
        isGameOver = false;
        SceneManager.LoadScene(2);
    }

    public void GameOver()
    {
        if(!isGameOver)
        {
            gameOverSound.Play();
            isGameOver = true;
            Time.timeScale = 0f;
            StateNameController.isPaused = true; 
            gameOverMenu.SetActive(true);
            scoreBackground.gameObject.GetComponent<RectTransform>().anchoredPosition  = new Vector3(836f, -300f, 0f);
            scoreBackground.enabled = false;
        }
        
    }

}
