using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VolumeHandler : MonoBehaviour
{
    //public AudioMixer audioMixer;

    public TextMeshProUGUI[] valueText;
    public Slider[] sliderValue;
    public Toggle[] toggle;


    private void Start()
    {
        for (int i = 0; i < valueText.Length; i++)
        {
            int num = i;
            if(GameManager.instance.volData.enabled[i])
            {
                toggle[i].isOn = true;
            }
            else
            {
                toggle[i].isOn = false;
            }

            sliderValue[i].value = GameManager.instance.volData.volume[i];
            valueText[i].text = string.Format("{0:0}%", GameManager.instance.volData.volume[i] * 100f);

            sliderValue[i].onValueChanged.AddListener((val)=>OnAudioChange(num,val));
            toggle[i].onValueChanged.AddListener((boo) => EnableVolume(num, boo));
        }
    }

    private void OnDisable()
    {
        GameManager.instance.SaveVolumeSettings();
    }

    public void OnAudioChange(int index, float val)
    {
        float finalVol = Mathf.Log10(val)*20;
        if (index == 0)
        {
            GameManager.instance.volData.volume[0] = val;
            if (GameManager.instance.volData.enabled[0])
            {
                GameManager.instance.audioMixer.SetFloat("Master", finalVol);
            }
        }
        else if (index == 1)
        {
            GameManager.instance.volData.volume[1] = val;
            if (GameManager.instance.volData.enabled[1])
            {
                GameManager.instance.audioMixer.SetFloat("BGM", finalVol);
            }
        }
        else
        {
            GameManager.instance.volData.volume[2] = val;
            if (GameManager.instance.volData.enabled[2])
            {
                GameManager.instance.audioMixer.SetFloat("SFX", finalVol);
            }
        }

        valueText[index].text = string.Format("{0:0}%",val * 100f);
    }

    public void EnableVolume(int index, bool enable)
    {
        if (index == 0)
        {
            GameManager.instance.volData.enabled[0] = enable;
            if (GameManager.instance.volData.enabled[0])
            {
                float finalVol = Mathf.Log10(GameManager.instance.volData.volume[0])*20;
                GameManager.instance.audioMixer.SetFloat("Master", finalVol);
            }
            else
            {
                GameManager.instance.audioMixer.SetFloat("Master", -90f);
            }
        }
        else if (index == 1)
        {
            GameManager.instance.volData.enabled[1] = enable;
            if (GameManager.instance.volData.enabled[1])
            {
                float finalVol = Mathf.Log10(GameManager.instance.volData.volume[1]) * 20;
                GameManager.instance.audioMixer.SetFloat("BGM", finalVol);
            }
            else
            {
                GameManager.instance.audioMixer.SetFloat("BGM", -90f);
            }
        }
        else
        {
            GameManager.instance.volData.enabled[0] = enable;
            if (GameManager.instance.volData.enabled[2])
            {
                float finalVol = Mathf.Log10(GameManager.instance.volData.volume[2]) * 20;
                GameManager.instance.audioMixer.SetFloat("SFX", finalVol);
            }
            else
            {
                GameManager.instance.audioMixer.SetFloat("SFX", -90F);
            }
        }
    }
}
