using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivateNext : MonoBehaviour
{
    private float timeHandle;
    public float ActiveTime;
    public GameObject objToActivate;
    public bool endOfLine;

    private void Update()
    {
        timeHandle += Time.deltaTime;
        if(timeHandle>ActiveTime)
        {
            
            if(endOfLine)
            {
                SceneManager.LoadScene(sceneBuildIndex:0);
            }
            else
            {
                gameObject.SetActive(false);
                objToActivate.SetActive(true);
            }
        }
    }
}
