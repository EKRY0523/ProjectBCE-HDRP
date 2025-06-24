using UnityEngine;
using UnityEngine.Audio;
public class BGMChanger : EventHandler
{
    AudioSource source;
    public AudioClip TownTheme;

    public override void Awake()
    {
        base.Awake();
        source = GetComponent<AudioSource>();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is AudioClip)
        {
            if(source.clip != (AudioClip)data)
            {
                source.clip = (AudioClip)data;
                source.Play();
            }
        }
        else
        {
            if (source.clip != TownTheme)
            {
                source.clip = TownTheme;
                source.Play();
            }
        }
    }
}
