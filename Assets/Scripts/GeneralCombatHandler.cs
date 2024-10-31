using UnityEngine;

public class GeneralCombatHandler : EventHandler
{
    public SkillHandler[] skillHandlers;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
        if((bool)data)
        {
            for (int i = 0; i < skillHandlers.Length; i++)
            {
                skillHandlers[i].input.action.Disable();
            }
        }
        else
        {
            for (int i = 0; i < skillHandlers.Length; i++)
            {
                skillHandlers[i].input.action.Enable();
            }
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID,data);
    }
}
