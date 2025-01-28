using UnityEngine;
using UnityEngine.UI;
public class Quit : MonoBehaviour
{
    Button quit;
    private void Awake()
    {
        quit = GetComponent<Button>();
    }

    private void Start()
    {
        quit = GetComponent<Button>();

        quit.onClick.AddListener(QuitApplication);
    }
    private void OnEnable()
    {
        quit.onClick.AddListener(QuitApplication);
    }

    private void QuitApplication()
    {
        Application.Quit();
    }
}
