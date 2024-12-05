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
            GameManager.instance.charactersInParty.Remove(GameManager.instance.characterLoading[characterData.character.ID]);
            GameManager.instance.deadCharacters.Add(GameManager.instance.characterLoading[characterData.character.ID]);

            party.SwitchUponDead();

        }
    }


}
