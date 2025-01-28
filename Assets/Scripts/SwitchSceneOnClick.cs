using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSceneOnClick : MonoBehaviour
{
    Button button;
    public LoadingScreeen loadScreen;
    public int scene;
    private void Start()
    {
        button= GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        loadScreen.sceneIndex= scene;
        Time.timeScale = 1;
        loadScreen.gameObject.SetActive(true);
    }
}