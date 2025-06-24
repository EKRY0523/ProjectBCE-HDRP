using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelStatusHandler : EventHandler
{
    public Entity entity;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI expStatus;
    public Image expFill;
    public override void OnInvoke(Trait ID, object data)
    {
        if (data is PlayableCharacterData)
        {
            entity = (PlayableCharacterData)data;
            if (entity != null)
            {
                Unsubscribe(entity);
            }
            entity = (PlayableCharacterData)data;
            Subscribe(entity);

            expFill.fillAmount = entity.currentEXP / entity.ExpNeeded;
            expStatus.text = "EXP: " + string.Format("{0:0}%", (entity.currentEXP / entity.ExpNeeded) * 100);
            LevelText.text = "Lv" + entity.lv;
        }

        if(data is float)
        {
            expFill.fillAmount = entity.currentEXP / entity.ExpNeeded;
            expStatus.text = "EXP: " + string.Format("{0:0}%", (entity.currentEXP / entity.ExpNeeded) * 100);
            LevelText.text = "Lv" + entity.lv;
        }
    }

}
