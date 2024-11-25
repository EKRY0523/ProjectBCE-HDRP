using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class MainMenuScript : EventHandler
{
    public Button NewGame;
    public Button Continue;
    public Button Settings;
    public GameObject ConfirmationPanel;
    public Button Confirm, Cancel;
    public override void Awake()
    {
        base.Awake();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
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
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }

    public void ConfirmationToStart()
    {
        File.Delete(Application.persistentDataPath + "/SaveFile.json");
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void CancelNewGame()
    {
        ConfirmationPanel.SetActive(false);
    }

    public void ContinueGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile.json"))
        {
            SceneManager.LoadScene(sceneBuildIndex:2);
        }
    }
}
