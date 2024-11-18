using UnityEngine;
using UnityEngine.InputSystem;
public class UiPauser : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActionReference[] InputToDisable;
    public GameObject[] gameObjectToClose;

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
        playerInput.input.Player.Disable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        playerInput.input.Player.Disable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        if(gameObject!=null)
        {
            for (int i = 0; i < InputToDisable.Length; i++)
            {
                InputToDisable[i].action.Enable();
            }
            for (int i = 0; i < gameObjectToClose.Length; i++)
            {
                gameObjectToClose[i].gameObject.SetActive(true);
            }
            playerInput.input.Player.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }
}
