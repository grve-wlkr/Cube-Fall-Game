using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private static bool hasGameStarted = false; // Flag to track if the game has started

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (hasGameStarted)
        {
            StartGame();
        }
        else
        {
            // First time the game is launched, show the main menu
            Time.timeScale = 0f;
            if (UIManager.instance != null)
            {
                UIManager.instance.ShowMainMenu();
            }
        }
    }

    public void StartGame()
    {
        hasGameStarted = true; // Set the flag to true when the game starts
        Time.timeScale = 1f; // Resume the game

        if (UIManager.instance != null)
        {
            UIManager.instance.HideMainMenu();
            UIManager.instance.HideGameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Freeze the game physics and spawners

        if (UIManager.instance != null)
        {
            UIManager.instance.ShowGameOver();
        }
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f; // Must unfreeze the game before restarting
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Unfreeze the game before quitting

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #else
            Application.Quit(); // Quit the application in a build
        #endif
    }




} // class
