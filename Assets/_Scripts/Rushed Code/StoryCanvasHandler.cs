using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryCanvasHandler : EventHandler
{
    public TextMeshProUGUI description;

    public override void Awake()
    {
        base.Awake();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);

            description.text = (string)data;
    
    }

    
}
