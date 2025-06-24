using UnityEngine;

public class TownSafeZone : MonoBehaviour
{
    public PartyHandler handler;
    public GameObject notifText;
    public GameObject VFX;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < GameManager.instance.deadCharacters.Count; i++)
            {
                GameManager.instance.characterLoading[GameManager.instance.deadCharacters[i].character.ID].gameObject.SetActive(true);

                if (GameManager.instance.characterLoading[GameManager.instance.deadCharacters[i].character.ID])
                {
                    for (int j = 0; j < GameManager.instance.deadCharacters[i].stats.Count; j++)
                    {
                        GameManager.instance.deadCharacters[i].statDictionary[GameManager.instance.deadCharacters[i].stats[j].statIdentifier].statValue =
                            GameManager.instance.deadCharacters[i].statDictionary[GameManager.instance.deadCharacters[i].stats[j].statIdentifier].MinMaxValue[1];
                    }
                }
                GameManager.instance.characterLoading[GameManager.instance.deadCharacters[i].character.ID].gameObject.SetActive(false);
            }

            GameManager.instance.deadCharacters.Clear();

            for (int i = 0; i < GameManager.instance.charactersInParty.Count; i++)
            {
                GameManager.instance.characterLoading[GameManager.instance.charactersInParty[i].character.ID].gameObject.SetActive(true);
                if (GameManager.instance.characterLoading[GameManager.instance.charactersInParty[i].character.ID])
                {
                    for (int j = 0; j < GameManager.instance.charactersInParty[i].stats.Count; j++)
                    {
                        GameManager.instance.charactersInParty[i].statDictionary[GameManager.instance.charactersInParty[i].stats[j].statIdentifier].statValue =
                        GameManager.instance.charactersInParty[i].statDictionary[GameManager.instance.charactersInParty[i].stats[j].statIdentifier].MinMaxValue[1];
                    }
                }
                GameManager.instance.characterLoading[GameManager.instance.charactersInParty[i].character.ID].gameObject.SetActive(false);


            }

            GameManager.instance.characterLoading[handler.activeCharacter.character.ID].gameObject.SetActive(true);
            notifText.SetActive(true);
            Invoke(nameof(DisableText),3f);
            Instantiate(VFX,other.transform);
            handler.MBEvent?.Invoke(null,handler.party);
        }
    }

    public void DisableText()
    {
        if(notifText.activeSelf)
        {
            notifText.SetActive(false);
        }
    }
}
