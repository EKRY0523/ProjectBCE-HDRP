using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] public Overlay overlay;
    [SerializeField] public GameObject inventory;
    [SerializeField] public GameObject questMenu;
    [SerializeField] public GameObject statMenu;
    [SerializeField] public GameObject skillTreeSelection;
    [SerializeField] public GameObject skillInput;
    [SerializeField] public Button backButton;
    //[SerializeField] public GameObject skillTree;

    //public GameManager gameManager;
    //public CharacterHolder character;

    private void Awake()
    {
        Instance = this;
    }
    //void Start()
    //{
    //    gameManager = GameManager.instance;
    //    //skillInput.GetComponent<SkillInput>().initialize();
    //    backButton.onClick.AddListener(turnOnOverlay);

    //}

    //private void Update()
    //{

    //}
    //public void turnOnOverlay()
    //{
    //    inventory.SetActive(false);
    //    questMenu.SetActive(false);
    //    statMenu.SetActive(false);
    //    skillInput.SetActive(false);
    //    overlay.SetActive(true);
    //    overlay.GetComponent<Overlay>().initialize();
    //    //backButton.gameObject.SetActive(false);


    //}

    //public void turnOnInventory()
    //{
    //    overlay.SetActive(false);
    //    inventory.SetActive(true);
    //    backButton.gameObject.SetActive(true);
    //    Player.instance.input.playerActions.Disable();
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //}

    //public void turnOnQuestMenu()
    //{
    //    overlay.SetActive(false);
    //    questMenu.SetActive(true);
    //    backButton.gameObject.SetActive(true);
    //    Player.instance.input.playerActions.Disable();
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;

    //}

    //public void turnOnStatMenu()
    //{
    //    overlay.SetActive(false);
    //    statMenu.SetActive(true);
    //    backButton.gameObject.SetActive(true);
    //    Player.instance.input.playerActions.Disable();
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;

    //}
    //public void turnOnSkillTreeSelect()
    //{
    //    overlay.SetActive(false);
    //    skillInput.SetActive(true);
    //    backButton.gameObject.SetActive(true);
    //    Player.instance.input.playerActions.Disable();
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;

    //}

}
