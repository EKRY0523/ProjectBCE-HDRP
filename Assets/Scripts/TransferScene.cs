using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransferScene : EventHandler
{
    public InputActionReference transferArea;

    public int index;
    public StoryHandler storyHandler;
    public bool inArea;
    public int sceneIndex;
    public Button transferButton;
    public LoadingScreeen loadScreen;
    public override void Awake()
    {
        base.Awake();
        transferArea.action.performed += Transfer;
        transferButton.onClick.AddListener(TransferArea);
    }

    private void OnEnable()
    {
        storyHandler.StoryChecker(index);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        transferArea.action.performed -= Transfer;
    }

    private void OnTriggerEnter(Collider other)
    {
        inArea = true;
        transferButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inArea = false;

        transferButton.gameObject.SetActive(false);
    }

    public void TransferArea()
    {
        if (inArea)
        {
            loadScreen.sceneIndex = sceneIndex;
            storyHandler.StoryChecker(9);
            loadScreen.gameObject.SetActive(true);
            //SceneManager.LoadScene(sceneBuildIndex: sceneIndex);
        }
    }
    public void Transfer(InputAction.CallbackContext ctx)
    {
        TransferArea();
    }
}