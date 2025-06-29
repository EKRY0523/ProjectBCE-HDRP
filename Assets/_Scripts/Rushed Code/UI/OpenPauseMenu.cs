using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class OpenPauseMenu : EventHandler
{
    public InputActionReference input;
    public GameObject[] turnOn;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(TurnOnMenu);
    }

    private void OnEnable()
    {
        if (input != null)
        {
            input.action.performed += TurnOnMenuViaShortcut;
        }
    }
    private void OnDisable()
    {
        if (input != null)
        {
            input.action.performed -= TurnOnMenuViaShortcut;
        }
    }
    public void TurnOnMenuViaShortcut(InputAction.CallbackContext ctx)
    {
        TurnOnMenu();
    }

    public void TurnOnMenu()
    {
        Time.timeScale = 0;
        for (int i = 0; i < turnOn.Length; i++)
        {
            turnOn[i].SetActive(true);
        }
    }


}
