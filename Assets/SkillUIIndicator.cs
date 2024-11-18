using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillUIIndicator : EventHandler
{
    public enum SkillType
    {
        basic, S1, S2, dodge, Ult
    }

    public PlayableCharacterData characterData;
    public TextMeshProUGUI costText;
    public Image icon;
    public Image fill;
    public SkillType skillType;

    public SkillHandler skillHandler;




    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
        if (data is PlayableCharacterData)
        {
            characterData = (PlayableCharacterData)data;
            if (skillType == SkillType.basic)
            {
                icon.sprite = characterData.character.BasicAttack[characterData.basicAttack].skillIcon;
                skillHandler = characterData.basic;
            }
            if (skillType == SkillType.S1)
            {
                icon.sprite = characterData.character.Skills[characterData.skill1].skillIcon;
                costText.text = characterData.character.Skills[characterData.skill1].cost.cost.ToString();
                skillHandler = characterData.firstSkill;
            }
            if (skillType == SkillType.S2)
            {
                icon.sprite = characterData.character.Skills[characterData.skill2].skillIcon;
                costText.text = characterData.character.Skills[characterData.skill2].cost.cost.ToString();
                skillHandler = characterData.secondSkill;
            }
            if (skillType == SkillType.dodge)
            {
                icon.sprite = characterData.character.Dodge[characterData.dodge].skillIcon;
                costText.text = characterData.character.Skills[characterData.dodge].cost.cost.ToString();
                skillHandler = characterData.dodgeSkill;
            }
            if (skillType == SkillType.Ult)
            {
                icon.sprite = characterData.character.Ultimate[characterData.ultimate].skillIcon;
                costText.text = characterData.character.Ultimate[characterData.ultimate].cost.cost.ToString();
                skillHandler = characterData.ultimateSkill;
            }
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }

    private void Update()
    {
        if(fill!=null)
        {
            fill.fillAmount = (skillHandler.timeToExceed + skillHandler.executionTime) - Time.time;
        }
    }
}
