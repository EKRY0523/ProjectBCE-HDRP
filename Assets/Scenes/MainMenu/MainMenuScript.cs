using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class MainMenuScript : EventHandler
{
    public Button NewGame;
    public Button Continue;
    public Button Settings;
    public Button creditbutton;
    public Button closeSettingsButton;

    public Button closecredit;


    public GameObject ConfirmationPanel;
    public GameObject creditpanel;
    public GameObject settingsMenu;
    public Button Confirm, Cancel;
    public LoadingScreeen loadScreen;
    public override void Awake()
    {
        base.Awake();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Start()
    {
        if(!File.Exists(Application.persistentDataPath + "/SaveFile.json"))
        {
            Continue.interactable = false;
        }
        else
        {
            Continue.interactable = true;
        }
        NewGame.onClick.AddListener(StartNewGame);
        Continue.onClick.AddListener(ContinueGame);
        Confirm.onClick.AddListener(ConfirmationToStart);
        Cancel.onClick.AddListener(CancelNewGame);
        Settings.onClick.AddListener(OpenSettings);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        creditbutton.onClick.AddListener(OpenCredit);
        closecredit.onClick.AddListener(CloseCredit);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);

        creditpanel.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void OpenCredit()
    {
        creditpanel.SetActive(true);

        settingsMenu.SetActive(false);
    }

    public void CloseCredit()
    {
        creditpanel.SetActive(false);
    }
    public void StartNewGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile.json"))
        {
            //prompt ui asking if sure onot
            ConfirmationPanel.SetActive(true);
        }
        else
        {
            loadScreen.sceneIndex=1;
            loadScreen.gameObject.SetActive(true);
            //SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }

    public void ConfirmationToStart()
    {
        File.Delete(Application.persistentDataPath + "/SaveFile.json");
        loadScreen.sceneIndex = 1;
        loadScreen.gameObject.SetActive(true);
        //SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void CancelNewGame()
    {
        ConfirmationPanel.SetActive(false);
    }

    public void ContinueGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile.json"))
        {
            loadScreen.sceneIndex = 2;
            loadScreen.gameObject.SetActive(true);
            //SceneManager.LoadScene(sceneBuildIndex:2);
        }
    }
}
