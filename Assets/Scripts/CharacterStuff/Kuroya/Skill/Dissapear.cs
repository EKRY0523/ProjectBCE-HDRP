using UnityEngine;
using DG.Tweening;
public class Dissapear : EventHandler
{
    public Material[] material;
    public float EquipDuration = 1f;
    public float UnequipDuration = 5f;
    public bool equipped;

    public void Equip()
    {
        gameObject.SetActive(true);
        CancelInvoke(nameof(TurnOffComponent));
        for (int i = 0; i < material.Length; i++)
        {
            material[i].DOFloat(0, "_Cutout", EquipDuration);
        }
    }

    public void Unequip()
    {
        for (int i = 0; i < material.Length; i++)
        {
            material[i].DOFloat(1, "_Cutout", UnequipDuration);
        }

        Invoke(nameof(TurnOffComponent), UnequipDuration);

    }

    public void TurnOffComponent()
    {
        gameObject.SetActive(true);
    }


    public override void EnableComponent(Trait ID, bool enabled)
    {
        base.EnableComponent(ID, enabled);
        if (ID == HandlerID)
        {
            if (enabled)
            {
                Equip();
            }
            else
            {
                Unequip();
            }
        }
    }

}
