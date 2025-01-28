using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreeen : MonoBehaviour
{
    public int sceneIndex;
    public Slider progressBar;

    [SerializeField] private float minimumLoadingTime = 2f; 
    [SerializeField] private float fakeProgressSpeed = 0.5f;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameManager.instance.SaveGame();
        }

        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;

        float elapsedTime = 0f; 
        float fakeProgress = 0f; 

        while (!asyncOperation.isDone)
        {
            if (fakeProgress < asyncOperation.progress)
            {
                fakeProgress += Time.deltaTime * fakeProgressSpeed;
                fakeProgress = Mathf.Clamp(fakeProgress, 0f, asyncOperation.progress);
            }

            // Calculate the total progress
            float totalProgress = Mathf.Clamp01(fakeProgress / 0.9f);
            if (progressBar != null)
                progressBar.value = totalProgress;

            // Track elapsed time
            elapsedTime += Time.deltaTime;

            // Allow scene activation only after the minimum loading time has passed and the scene is ready
            if (asyncOperation.progress >= 0.9f && elapsedTime >= minimumLoadingTime)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }

        // Deactivate the loading screen once the scene is loaded
       
        gameObject.SetActive(false);
    }
}

