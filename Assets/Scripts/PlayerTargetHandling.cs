using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerTargetHandling : TargetHandling
{
    public InputActionReference[] input;
    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < input.Length; i++)
        {
            input[i].action.performed += GetTarget;
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        for (int i = 0; i < input.Length; i++)
        {
            input[i].action.performed -= GetTarget;
        }
    }
    public void GetTarget(InputAction.CallbackContext ctx)
    {
        targets.Clear();
        CheckTargetsValidity();
    }
}
