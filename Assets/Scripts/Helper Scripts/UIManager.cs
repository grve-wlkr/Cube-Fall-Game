using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Controls")]
    [SerializeField] private GameObject joystickBackground;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowMainMenu()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        SetJoystickVisible(false);
    }

    public void HideMainMenu()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        SetJoystickVisible(true);
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        SetJoystickVisible(false);
    }

    public void HideGameOver()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    private void SetJoystickVisible(bool isVisible)
    {
        if (joystickBackground != null)
            joystickBackground.SetActive(isVisible);
    }

    public void OnPlayButtonClicked()
    {
        GameManager.instance.StartGame();
    }

    public void OnRestartButtonClicked()
    {
        GameManager.instance.RestartGame();
    }

    public void OnQuitButtonClicked()
    {
        GameManager.instance.QuitGame();
    }








} // class
