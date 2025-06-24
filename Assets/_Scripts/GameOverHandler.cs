using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameOverHandler : EventHandler
{
    public Button mainMenuButton, respawnButton;
    public PartyHandler partyHandler;
    public Transform safePoint;
    public override void Awake()
    {
        base.Awake();
        respawnButton.onClick.AddListener(RespawnToSafety);
        mainMenuButton.onClick.AddListener(BackToMain);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void BackToMain()
    {
        Respawn();
        TpToSafePoint();
        SceneManager.LoadScene(sceneBuildIndex:0);
    }

    public void RespawnToSafety()
    {
        gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(sceneBuildIndex: 3);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Respawn();
        }
        else
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        TpToSafePoint();
        
        for (int i = 0; i < GameManager.instance.deadCharacters.Count; i++)
        {
            if(!partyHandler.party.Contains(GameManager.instance.characterLoading[GameManager.instance.deadCharacters[i].character.ID]))
            {
                GameManager.instance.charactersInParty.Add(GameManager.instance.characterLoading[GameManager.instance.deadCharacters[i].character.ID]);
                GameManager.instance.characterLoading[GameManager.instance.deadCharacters[i].character.ID].gameObject.SetActive(true);
                for (int j = 0; j < GameManager.instance.charactersInParty[i].stats.Count; j++)
                {
                    GameManager.instance.charactersInParty[i].statDictionary[GameManager.instance.charactersInParty[i].stats[j].statIdentifier].statValue =
                        GameManager.instance.charactersInParty[i].statDictionary[GameManager.instance.charactersInParty[i].stats[j].statIdentifier].MinMaxValue[1];
                }
                GameManager.instance.characterLoading[GameManager.instance.deadCharacters[i].character.ID].gameObject.SetActive(false);
            }
            

        }
        GameManager.instance.deadCharacters.Clear();

        partyHandler.OnInitialization();
        gameObject.SetActive(false);
    }

    public void TpToSafePoint()
    {   
        if(safePoint!=null)
        {
            partyHandler.GetComponent<PlayerMovement>().enabled = false;
            partyHandler.transform.position = safePoint.position;
            partyHandler.GetComponent<PlayerMovement>().enabled = true;
            //partyHandler.transform.DOMove(safePoint.position,1f);
        }
    }
}
