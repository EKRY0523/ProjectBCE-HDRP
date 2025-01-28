using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class SkillTutorial : MonoBehaviour
{
    public Animator animator;
    public Button button;
    public InputActionReference action;
    private void Start()
    {
        animator.SetTrigger("blink");
        action.action.performed += TurnOffInput;
        button.onClick.AddListener(TurnOff);
    }

    private void OnDisable()
    {
        action.action.performed -= TurnOffInput;

    }
    private void TurnOffInput(InputAction.CallbackContext ctx)
    {
        TurnOff();

    }
    private void TurnOff()
    {

        gameObject.SetActive(false);
    }

}
