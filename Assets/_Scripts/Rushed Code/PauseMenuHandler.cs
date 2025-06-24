using UnityEngine;
using UnityEngine.UI;
public class PauseMenuHandler : MonoBehaviour
{
    public Button settingsButton;
    public Button ResumeButton;
    public Button BackToMain;

    public GameObject settingsPanel;

    public LoadingScreeen loadingScreen;
    private void Start()
    {
        settingsButton.onClick.AddListener(OpenSettings);
        ResumeButton.onClick.AddListener(Resume);
        BackToMain.onClick.AddListener(BackToMainMenu);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void Resume()
    {
        settingsPanel.SetActive(false);

        gameObject.SetActive(false);
       
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        loadingScreen.sceneIndex = 0;
        Time.timeScale = 1;
        loadingScreen.gameObject.SetActive(true);
    }
}
