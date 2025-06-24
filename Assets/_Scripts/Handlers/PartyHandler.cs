using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class PartyHandler : EventHandler
{
    public Transform safeHaven;
    [SerializeField]protected PlayerInput playerInput;
    public PlayableCharacterData activeCharacter;
    public int deadCount;


    public List<PlayableCharacterData> party = new();
    public List<PlayableCharacterData> deadCharList = new();

    public GameObject backLine;
    public bool CanSwitch;
    public float SwitchCD;
    public float timeSinceLastSwitch;

    public GameObject gameOverMenu;

    //public CharacterStatusHandler mainStatusHandler;

    public override void Awake()
    {
        base.Awake();
        playerInput.SwitchOne += OnCharacterChange;
        playerInput.SwitchTwo += OnCharacterChange;
        playerInput.SwitchThree += OnCharacterChange;
    }

    private void Start()
    {
        party = GameManager.instance.charactersInParty;
        if(party.Count>0)
        {
            OnInitialization();
        }
        else
        {
            gameOverMenu.SetActive(true);
        }
    }

    public void OnInitialization()
    {
        for (int i = 0; i < party.Count; i++)
        {
            party[i].gameObject.transform.parent = transform;
            party[i].AddInParty();
            party[i].transform.SetSiblingIndex(i);
            party[i].characterStatus.transform.SetSiblingIndex(i);
        }
        activeCharacter = party[0];
        activeCharacter.gameObject.SetActive(true);

        MBEvent?.Invoke(null, party);
        MBEvent?.Invoke(null, activeCharacter);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        playerInput.SwitchOne -= OnCharacterChange;
        playerInput.SwitchTwo -= OnCharacterChange;
        playerInput.SwitchThree -= OnCharacterChange;
    }

    private void Update()
    {
        if(Time.time>timeSinceLastSwitch+SwitchCD)
        {
            CanSwitch = true;
        }
    }

    public void SwitchUponDead()
    {
        gameObject.tag = "Invulnerable";
        Invoke(nameof(SwitchAndUnsetInvul),1.5f);

    }

    public void SwitchAndUnsetInvul()
    {
        activeCharacter.gameObject.SetActive(false);
        if (party.Count > 0)
        {
            activeCharacter = party[0];
            activeCharacter.gameObject.SetActive(true);
            MBEvent?.Invoke(null, party);
            MBEvent?.Invoke(null, activeCharacter);
        }
        else
        {
            activeCharacter.gameObject.SetActive(false);
            gameOverMenu.SetActive(true);
        }
        Invoke(nameof(InvulOff), 1f);
    }

    public void InvulOff()
    {
        gameObject.tag = "Player";
    }
    public void OnCharacterChange(int index)
    {

        if (index < party.Count)
        {
            if(index != party.IndexOf(activeCharacter))
            {
                if (CanSwitch)
                {
                    timeSinceLastSwitch = Time.time;
                    CanSwitch = false;
                    MBEvent?.Invoke(null, party);
                    activeCharacter.gameObject.SetActive(false);
                    activeCharacter = party[index];
                    activeCharacter.gameObject.SetActive(true);

                    MBEvent?.Invoke(null, party);
                    MBEvent?.Invoke(null, activeCharacter);
                }
            }
        }

    }



    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
        if (data == null)
        {
            for (int i = 0; i < party.Count; i++)
            {
                party[i].gameObject.SetActive(false);
                party[i].AddInParty();
                party[i].transform.SetSiblingIndex(i);
                party[i].characterStatus.transform.SetSiblingIndex(i);
            }

            activeCharacter = party[0];
            activeCharacter.gameObject.SetActive(true);
            MBEvent?.Invoke(null, party);
            MBEvent?.Invoke(null, activeCharacter);

            //change party?
            //SOEvent[0].globalEvent?.Invoke(activeCharacter);
            //fuck this, make it instant ref instead
            
        }
    }
    
    
}
