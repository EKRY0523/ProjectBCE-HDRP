using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class playerAnimationData
{
    [Header("State Group Parameter Names")]
    [SerializeField] private string groundedParameterName = "Grounded";
    [SerializeField] private string onAirParameterName = "onAir";
    [SerializeField] private string combatParameterName = "Combat";

    //[SerializeField] private string isFightingParameterName = "isFighting";

    [Header("Grounded Parameter Names")]
    [SerializeField] private string idleParameterName = "Idling";
    [SerializeField] private string runParameterName = "Running";

    [Header("Airborne Parameter Names")]
    [SerializeField] private string fallParameterName = "Falling";

    [Header("Combat Parameter Names")]
    [SerializeField] private string Chain1ParameterName = "Chain1";
    [SerializeField] private string Chain2ParameterName = "Chain2";
    [SerializeField] private string Chain3ParameterName = "Chain3";

    [SerializeField] private string SkillParameterName = "Skill";
    [SerializeField] private string Skill1ParameterName = "Skill1";
    [SerializeField] private string Skill2ParameterName = "Skill2";
    [SerializeField] private string Skill3ParameterName = "Skill3";

    public int GroundedParameterHash { get; private set; }
    public int onAirParameterHash { get; private set; }
    public int combatParameterHash { get; private set; }

    public int IdleParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    public int Chain1ParameterHash { get; private set; }
    public int Chain2ParameterHash { get; private set; }
    public int Chain3ParameterHash { get; private set; }

    public int SkillParameterHash { get; private set; }
    public int Skill1ParameterHash { get; private set; }
    public int Skill2ParameterHash { get; private set; }    
    public int Skill3ParameterHash { get; private set; }

    public void Initialize()
    {
        GroundedParameterHash = Animator.StringToHash(groundedParameterName);
        onAirParameterHash = Animator.StringToHash(onAirParameterName);

        combatParameterHash = Animator.StringToHash(combatParameterName);

        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        FallParameterHash = Animator.StringToHash(fallParameterName);

        Chain1ParameterHash = Animator.StringToHash(Chain1ParameterName);
        Chain2ParameterHash = Animator.StringToHash(Chain2ParameterName);
        Chain3ParameterHash = Animator.StringToHash(Chain3ParameterName);

        SkillParameterHash = Animator.StringToHash(SkillParameterName);
        Skill1ParameterHash = Animator.StringToHash(Skill1ParameterName);
        Skill2ParameterHash = Animator.StringToHash(Skill2ParameterName);
        Skill3ParameterHash = Animator.StringToHash(Skill3ParameterName);

    }
}
