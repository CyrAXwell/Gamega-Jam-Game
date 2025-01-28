using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public const string BLOCK_GAME_OBJECT_TAG = "Block";
    public const string PLAYER_GAME_OBJECT_TAG = "Player";

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Image _scoreBackground;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] AudioSource _gameOverSound;

    private bool _isGameOver = false;

    private void Start()
    {
        Time.timeScale = 1f;
        StateNameController.IsGamePaused = false; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !_isGameOver)
        {
            if(StateNameController.IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        _scoreBackground.enabled = true;

        Time.timeScale = 1f;
        StateNameController.IsGamePaused = false; 
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _scoreBackground.enabled = false;

        Time.timeScale = 0f;
        StateNameController.IsGamePaused = true; 
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
        _isGameOver = false;
        SceneManager.LoadScene(2);
    }

    public void GameOver()
    {
        if(!_isGameOver)
        {
            _isGameOver = true;
            Time.timeScale = 0f;
            StateNameController.IsGamePaused = true; 

            _scoreBackground.gameObject.GetComponent<RectTransform>().anchoredPosition  = new Vector3(836f, -300f, 0f);
            _scoreBackground.enabled = false;

            _gameOverMenu.SetActive(true);
            _gameOverSound.Play();
            
        }
    }
}
