using UnityEngine;
using System.Collections.Generic;
public class DictionaryStorage : MonoBehaviour
{
    public Trait[] traits = null;
    public static Dictionary<int, Trait> TraitDictionary = new();

    private void Awake()
    {
        for (int i = 0; i < traits.Length; i++)
        {
            if(!TraitDictionary.ContainsKey(traits[i].key))
            {

                TraitDictionary.Add(traits[i].key, traits[i]);
            }
        }
    }
}
