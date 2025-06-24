using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SwitchBGMOnenable : EventHandler
{
    public AudioClip bgm;
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {

        MBEvent?.Invoke(null, bgm);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    private void OnEnable()
    {
        MBEvent?.Invoke(null,bgm);
    }

    private void OnDisable()
    {
        MBEvent?.Invoke(null, null);
    }

}
