using UnityEngine;
using UnityEngine.InputSystem;
public class UiPauser : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActionReference[] InputToDisable;
    public GameObject[] gameObjectToClose;
    public bool tutorialMode;
    private void Start()
    {
        for (int i = 0; i < InputToDisable.Length; i++)
        {
            InputToDisable[i].action.Disable();
        }
        for (int i = 0; i < gameObjectToClose.Length; i++)
        {
            gameObjectToClose[i].gameObject.SetActive(false);
        }
        if (playerInput != null)
        {
            playerInput.input.Player.Disable();
        }
        if(!tutorialMode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < InputToDisable.Length; i++)
        {
            InputToDisable[i].action.Disable();
        }
        for(int i = 0; i < gameObjectToClose.Length; i++)
        {
            gameObjectToClose[i].gameObject.SetActive(false);
        }
        if(playerInput!=null)
        {

            playerInput.input.Player.Disable();
        }
        if(!tutorialMode)
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void OnDisable()
    {
        if (gameObject != null)
        {
            for (int i = 0; i < InputToDisable.Length; i++)
            {
                InputToDisable[i].action.Enable();
            }
            for (int i = 0; i < gameObjectToClose.Length; i++)
            {
                if(gameObjectToClose[i]!=null)
                {

                    if (!gameObjectToClose[i].gameObject.activeSelf)
                    {
                        gameObjectToClose[i].gameObject.SetActive(true);
                    }
                }
            }
            if (playerInput != null)
            {


                playerInput.input.Player.Enable();
            }
            if (!tutorialMode)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }
}
