using UnityEngine;
using UnityEngine.InputSystem;
public class DisableSelfUI : EventHandler
{
    public InputActionReference[] input;
    public Animator animator;

    public override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        for (int i = 0; i < input.Length; i++)
        {

            input[i].action.performed += EnterStage;
        }
        animator = GetComponent<Animator>();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void OnDisable()
    {
        for (int i = 0; i < input.Length; i++)
        {

            input[i].action.performed -= EnterStage;
        }
    }
    public void SelfDisable()
    {
        gameObject.SetActive(false);
    }

    public void EnterStage(InputAction.CallbackContext ctx)
    {
        animator.SetTrigger("met");
    }
}
