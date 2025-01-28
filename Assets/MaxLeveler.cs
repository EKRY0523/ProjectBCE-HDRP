using UnityEngine;
using UnityEngine.InputSystem;
public class MaxLeveler : MonoBehaviour
{
    public InputActionReference cheatKey;
    public ExpMat exp,test;
    public Transform playerPos;
    private void Start()
    {
        cheatKey.action.performed += LevelUp;
    }
    private void OnDestroy()
    {
        cheatKey.action.performed -= LevelUp;
    }
    public void LevelUp(InputAction.CallbackContext ctx)
    {
        test = Instantiate(exp , playerPos);
        test.transform.position = playerPos.position;
        test.exp = 1000;
    }
}
