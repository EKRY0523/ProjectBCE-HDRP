using UnityEngine;
using System.Collections.Generic;
public class CharacterSelectionSwitch : EventHandler
{
    public List<Character> characterIndex;
    public GameObject[] characters;
    public GameObject currentActive;
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        currentActive.SetActive(false);
        currentActive = characters[characterIndex.IndexOf((Character)data)];
        currentActive.SetActive(true);

    }
}
