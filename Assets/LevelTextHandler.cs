using UnityEngine;
using TMPro;
public class LevelTextHandler : EventHandler
{
    public Entity entity;
    public Level lv;
    public TextMeshProUGUI text;
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
        }

        if(data is Level)
        {
            lv = (Level)data;
            text.text = "Lv" + lv.lv;
        }
    }

}
