using UnityEngine;
using UnityEngine.InputSystem;
public class UIClickHandler : MonoBehaviour
{
    public InputActionReference click;
    public float duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        click.action.performed += clickDelay;
    }
    private void OnDisable()
    {
        click.action.performed -= clickDelay;
    }
    public void clickDelay(InputAction.CallbackContext ctx)
    {
        Invoke(nameof(CloseObj),duration);
    }

    public void CloseObj()
    {
        gameObject.SetActive(false);
    }
}
