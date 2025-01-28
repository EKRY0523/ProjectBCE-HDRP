using UnityEngine;

public class CharacterDeathHandler : EventHandler
{
    public PlayableCharacterData characterData;
    public Trait deadID;
    public PartyHandler party;

    public override void Awake()
    {
        base.Awake();
        party = GetComponentInParent<PartyHandler>();
        characterData = GetComponent<PlayableCharacterData>();
        
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(ID == deadID)
        {
            if(!GameManager.instance.deadCharacters.Contains(GameManager.instance.characterLoading[characterData.character.ID]))
            {
                GameManager.instance.charactersInParty.Remove(GameManager.instance.characterLoading[characterData.character.ID]);
                GameManager.instance.deadCharacters.Add(GameManager.instance.characterLoading[characterData.character.ID]);
            }

            party.SwitchUponDead();
            //test
            for (int i = 0; i < GameManager.instance.charactersInParty.Count; i++)
            {
                GameManager.instance.characterLoading[GameManager.instance.charactersInParty[i].character.ID].InitializeCharacter();
                GameManager.instance.characterLoading[GameManager.instance.charactersInParty[i].character.ID].GetComponent<EffectHandler>().ReloadPassive();
            }
        }
    }


}
