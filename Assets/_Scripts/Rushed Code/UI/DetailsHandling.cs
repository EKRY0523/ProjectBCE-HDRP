using UnityEngine;
using UnityEngine.UI;
public class DetailsHandling : EventHandler
{
    public Button detailButton, statButton, skillButon;
    public ShowCharacterStats statPanel;
    public ShowCharacterDetails detailsPanel;
    public SkillSwitchHandler skillSwitchHandler;
    public override void Awake()
    {
        base.Awake();
        detailButton.onClick.AddListener(ShowDetails);
        statButton.onClick.AddListener(ShowStats);
        skillButon.onClick.AddListener(ShowSkills);
    }

    public void ShowDetails()
    {
        statPanel.gameObject.SetActive(false);
        detailsPanel.gameObject.SetActive(true);
        skillSwitchHandler.gameObject.SetActive(false);
    }

    public void ShowStats()
    {
        statPanel.gameObject.SetActive(true);
        detailsPanel.gameObject.SetActive(false);
        skillSwitchHandler.gameObject.SetActive(false);
    }

    public void ShowSkills()
    {
        statPanel.gameObject.SetActive(false);
        detailsPanel.gameObject.SetActive(false);
        skillSwitchHandler.gameObject.SetActive(true);
    }

}
