using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToOtherScene : EventHandler
{
    public int sceneIndex;

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        SceneManager.LoadScene(sceneBuildIndex:sceneIndex);
        
    }

}
