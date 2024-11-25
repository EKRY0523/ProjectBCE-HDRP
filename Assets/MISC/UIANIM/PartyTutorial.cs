using UnityEngine;

public class PartyTutorial : MonoBehaviour
{
    public Animator animator;
    public GameObject[] walls;
    private void Start()
    {
        animator.SetTrigger("blink");
    }

    private void Update()
    {
        if(GameManager.instance.charactersInParty.Count>1)
        {
            gameObject.SetActive(false);
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].SetActive(false);
            }
        }
    }
}
