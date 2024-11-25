using UnityEngine;

public class CheckCharacterLevel : MonoBehaviour
{
    public int index;
    public GameObject flowchart;
    public StoryHandler handler;
    public PlayableCharacterData[] character;


    private void OnEnable()
    {
        StoryHandler.SetIndex(index);
        handler.StoryChecker(index);
    }

    private void Update()
    {
        for (int i = 0; i < character.Length; i++)
        {
            if(GameManager.instance.characterLoading[character[i].character.ID].lv>=15)
            {
                flowchart.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
