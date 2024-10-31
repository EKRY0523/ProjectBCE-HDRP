using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BasicAttacks : ScriptableObject
{
    public delegate void attackMethods();
    public OldPlayer player;

    [SerializeField] public AnimatorOverrideController animatorOverrideController;
    [SerializeField] public string attackName;
    [SerializeField] public Sprite attackIcon;
    //[SerializeField] AnimationClip[] attackClips;
    [SerializeField][Range(0, 5)] int attackLevel;
    [SerializeField] public float damage;
    [SerializeField] public float regenValue;

    List<attackMethods> attacks = new List<attackMethods>();
    
    public void initialize()
    {
        attacks.Add(attack1);
        attacks.Add(attack2);
        attacks.Add(attack3);
    }
    //attackMethods

    public abstract void attack1();
    public abstract void attack2();
    public abstract void attack3();


}
