using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerControl))]
public class OldPlayer : MonoBehaviour
{
    [SerializeField] GameObject damageText;
    [SerializeField] public List<GameObject> enemy = new List<GameObject>();
    [SerializeField] public GameObject targetEnemy;
    [SerializeField] Vector3 lookAtGoal;
    [SerializeField] Quaternion lookRotation;

    public static OldPlayer instance;
    public float moveSpeed;
    public float cooldown;
    //steps
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 2f;
    //

    [field: SerializeField] public playerAnimationData playerAnimationData { get; private set; }
    [SerializeField] public CharacterHolder characterHolder;
    public PlayerControl input { get; private set; }
    public Rigidbody rb;
    public Animator anim;

    public Transform cameraTransform;

    protected Vector3 currentTargetRotation;
    protected Vector3 timeToReachTargetRotation;
    Vector3 dampedTargetRotationCurrentVelocity;
    Vector3 dampedTargetRotationPassedTime;

    public float comboResetTimer;
    public float comboPassedTime;
    public int comboCount = 1;
    bool inCombat = false;

    #region stat values;
    public float ATK, EATK, Speed, CSPD, Def, Resist,MAXHP,MAXENG;
    public float currentHP,currentENG;
    public int totalStatPoints,availableStatPoints;
    public float experience;
    public int level;
    #endregion

    public BasicAttacks Basic;
    public CharacterAbility Skill1;
    public CharacterAbility Skill2;
    public CharacterAbility Dodge;
    public CharacterAbility Ultimate;


    #region states
    public OldStatemachine stateMachine { get; set; }
    public playerGroundedState groundedState { get; set; }
    public playerGroundedCombatState groundedCombatState { get; set; }
    public playerIdleState idleState { get; set; }
    public playerRunState runningState { get; set; }
    //public playerOnAirState onAirState { get; set; }
    //public playerFallingState fallState { get; set; }

    #endregion
    private void Awake()
    {
        OldPlayer.instance = this;
        playerAnimationData.Initialize();
        stateMachine = new OldStatemachine();
        groundedState = new playerGroundedState(this, stateMachine);
        groundedCombatState = new playerGroundedCombatState(this, stateMachine);
        idleState = new playerIdleState(this, stateMachine);
        runningState = new playerRunState(this, stateMachine);
        //onAirState = new playerOnAirState(this, stateMachine);
        //fallState = new playerFallingState(this, stateMachine);

        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
        
    }

    void Start()
    {

        anim = GetComponentInChildren<Animator>();
        timeToReachTargetRotation.y = 0.14f;
        input = GetComponent<PlayerControl>();
        rb = GetComponent<Rigidbody>();

        input.playerActions.Attack.started += onAttack;
        input.playerActions.Attack.performed += onChargedAttack;

        cameraTransform = Camera.main.transform;
        stateMachine.ChangeState(groundedState);

        characterHolder.attack.player = this;
        characterHolder.ability[0].Player = this;
        characterHolder.ability[1].Player = this;
        characterHolder.ability[2].Player = this;

        //characterHolder.overrideController = 
        currentHP = MAXHP;
        currentENG = MAXENG;
        level = characterHolder.Level;
        experience = characterHolder.exp;
        
        //initializeStat();
    }

    #region input
    private void onChargedAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("charge");
    }
    private void onAttack(InputAction.CallbackContext obj)
    {
        inCombat = true;
        comboPassedTime = Time.time;
        //Debug.Log("normal");
        stateMachine.ChangeState(groundedCombatState);
        stopAnim(playerAnimationData.Skill1ParameterHash);
        stopAnim(playerAnimationData.Skill2ParameterHash);
        stopAnim(playerAnimationData.Skill3ParameterHash);
        anim.runtimeAnimatorController = characterHolder.attack.animatorOverrideController;
        if (comboPassedTime - Time.time < comboResetTimer)
        {
            input.playerActions.Attack.Disable();
            input.playerActions.Skill1.Disable();
            input.playerActions.Skill2.Disable();
            input.playerActions.Ultimate.Disable();

            if (comboCount == 1)
            {
                Basic.attack1();
                comboCount++;
                comboCount = Mathf.Clamp(comboCount, 1, 2);
            }
            else if (comboCount == 2)
            {
                Basic.attack2();
                comboCount++;
                comboCount = Mathf.Clamp(comboCount, 2, 3);
            }
            else if (comboCount == 3)
            {
                Basic.attack3();
                comboCount = 1;
            }
        }
        if(targetEnemy)
        {
            lookAtGoal = targetEnemy.transform.position - this.transform.position;
            lookAtGoal.y = 0;
        }


        if (targetEnemy)
        {
            lookAtGoal = targetEnemy.transform.position - this.transform.position;
            lookAtGoal.y = 0;
            lookRotation = Quaternion.LookRotation(lookAtGoal);
            this.transform.rotation = lookRotation;
        }

    }
    #endregion
    private void Update()
    {
        if (enemy.Count > 0)
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if(!targetEnemy)
                {
                    if(enemy[i]!=null)
                    {
                        targetEnemy = enemy[i];
                    }
                    
                }
                if(targetEnemy)
                {
                    if (Vector3.Distance(this.transform.position, enemy[i].transform.position) < Vector3.Distance(this.transform.position, targetEnemy.transform.position))
                    {
                        if (enemy[i] != null)
                        {
                            targetEnemy = enemy[i];
                        }
                    }
                }
                
            }
        }

        if (input.playerActions.Skill1.IsPressed() && Skill1.skillCost<=currentENG)
        {
            //FindObjectOfType<Overlay>().cdValue1 = characterHolder.ability[0].cooldown;
            inCombat = true;
            anim.runtimeAnimatorController = Skill1.skillAnimation;
            stateMachine.ChangeState(groundedCombatState);
            Skill1.SkillUse();

            startAnim(playerAnimationData.Skill1ParameterHash);
            Skill1.SkillCooldown(1);

            stopAnim(playerAnimationData.Skill2ParameterHash);
            stopAnim(playerAnimationData.Skill3ParameterHash);

            input.playerActions.Skill1.Disable();
            comboPassedTime = Time.time;

            
            if(targetEnemy)
            {
                lookAtGoal = targetEnemy.transform.position - this.transform.position;
                lookAtGoal.y = 0;
                lookRotation = Quaternion.LookRotation(lookAtGoal);
                this.transform.rotation = lookRotation;
            }
            

        }

        else if (input.playerActions.Skill2.IsPressed() && Skill2.skillCost <= currentENG)
        {
            //FindObjectOfType<Overlay>().cdValue2 = characterHolder.ability[1].cooldown;
            inCombat = true;
            anim.runtimeAnimatorController = characterHolder.ability[1].skillAnimation;
            stateMachine.ChangeState(groundedCombatState);
            Skill2.SkillUse();

            startAnim(playerAnimationData.Skill2ParameterHash);
            Skill2.SkillCooldown(2);

            stopAnim(playerAnimationData.Skill1ParameterHash);
            stopAnim(playerAnimationData.Skill3ParameterHash);

            input.playerActions.Skill2.Disable();
            comboPassedTime = Time.time;

            if (targetEnemy)
            {
                lookAtGoal = targetEnemy.transform.position - this.transform.position;
                lookAtGoal.y = 0;
                lookRotation = Quaternion.LookRotation(lookAtGoal);
                this.transform.rotation = lookRotation;
            }

        }
        else if(input.playerActions.Ultimate.IsPressed() && Ultimate.skillCost <= currentENG)
        {
            //FindObjectOfType<Overlay>().cdValue3 = characterHolder.ability[2].cooldown;
            inCombat = true;
            anim.runtimeAnimatorController = characterHolder.ability[2].skillAnimation;
            stateMachine.ChangeState(groundedCombatState);
            Ultimate.SkillUse();

            startAnim(playerAnimationData.Skill3ParameterHash);
            Ultimate.SkillCooldown(3);

            stopAnim(playerAnimationData.Skill1ParameterHash);
            stopAnim(playerAnimationData.Skill2ParameterHash);

            input.playerActions.Ultimate.Disable();
            comboPassedTime = Time.time+0.5f;

            if (targetEnemy)
            {
                lookAtGoal = targetEnemy.transform.position - this.transform.position;
                lookAtGoal.y = 0;
                lookRotation = Quaternion.LookRotation(lookAtGoal);
                this.transform.rotation = lookRotation;
            }
        }

        IsGrounded();
        stateMachine.currentState.HandleInput();
        stateMachine.currentState.Update();

        if(Time.time > comboPassedTime + comboResetTimer && input.movementInput == Vector2.zero)
        {
            inCombat = false;
            stateMachine.ChangeState(idleState);
            comboCount = 1;

            stopAnim(playerAnimationData.Chain1ParameterHash);
            stopAnim(playerAnimationData.Chain2ParameterHash);
            stopAnim(playerAnimationData.Chain3ParameterHash);
            stopAnim(playerAnimationData.SkillParameterHash);
            stopAnim(playerAnimationData.Skill1ParameterHash);
            stopAnim(playerAnimationData.Skill2ParameterHash);
            stopAnim(playerAnimationData.Skill3ParameterHash);
        }
        
        //levelUp();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
        
        stepClimb();
        Move();
        if(!IsGrounded())
        {
            rb.AddForce(-Vector3.up * 9.81f * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    #region Stat Calculation
    public void initializeStat()
    {
        Debug.Log(ATK);
        
        //totalStatPoints = characterHolder.STR + characterHolder.ENG + characterHolder.AGI + characterHolder.DEX + characterHolder.MTL + characterHolder.VIT;
        //availableStatPoints = (characterHolder.Level * 3)-totalStatPoints;

        
        
        
    }

    //public void levelUp()
    //{
    //    float expNeeded;
    //    if(level == 1)
    //    {
    //        expNeeded = 100 * MathF.Pow(2,level - 2);
    //    }
    //    else
    //    {
    //        expNeeded = 100 * MathF.Pow(2,level - 1);
    //    }

    //    if(experience >= expNeeded)
    //    {
    //        level += 1;
    //        experience -= expNeeded;
            
    //    }

    //    characterHolder.exp = experience;
    //    characterHolder.Level = level;
    //}

    #endregion


    #region methods

    public bool IsGrounded()
    {
        float groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + 0.1f;
        RaycastHit hit;
        return Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance);

    }

    public void Move()
    {
        if (input.movementInput == Vector2.zero || inCombat == true)
        {
            return;
        }
        Vector3 movementDirection = GetMovementInputDirection();

        float targetRotationYAngle = Rotate(movementDirection);

        Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);
        Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();

        if (IsGrounded() && input.movementInput != Vector2.zero)
        {
            rb.AddForce(targetRotationDirection * moveSpeed - currentPlayerHorizontalVelocity, ForceMode.VelocityChange);
            stateMachine.ChangeState(runningState);
            //rb.velocity = Vector3.ClampMagnitude(rb.velocity, 7f);
        }
        
    }

    void stepClimb()
    {
        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
            {
                rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLower45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitLower45, 0.1f))
        {

            RaycastHit hitUpper45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitUpper45, 0.2f))
            {
                rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.1f))
        {

            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 0.2f))
            {
                rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
    }


    #region no need to edit
    protected Vector3 GetMovementInputDirection()
    {
        //return new Vector3(input.movementInput.x, playerVelocity.y, input.movementInput.y);
        return new Vector3(input.movementInput.x, 0, input.movementInput.y);
    }

    protected Vector3 GetPlayerHorizontalVelocity()
    {
        Vector3 playerHorizontalVelocity = rb.linearVelocity;

        playerHorizontalVelocity.y = 0f;

        return playerHorizontalVelocity;
    }
    public void startAnim(int animationHash)
    {
        anim.SetBool(animationHash, true);
    }

    public void stopAnim(int animationHash)
    {
        anim.SetBool(animationHash, false);
    }
    #endregion

    #region Rotation
    private float Rotate(Vector3 direction)
    {
        float directionAngle = UpdateTargetRotation(direction);

        RotateTowardsTargetRotation();

        return directionAngle;
    }
    private Vector3 GetTargetRotationDirection(float targetAngle)
    {
        return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    }
    private float UpdateTargetRotation(Vector3 direction)
    {
        float directionAngle = GetDirectionAngle(direction);

        directionAngle = AddCameraRotationToAngle(directionAngle);

        if (directionAngle != currentTargetRotation.y)
        {
            UpdateTargetRotationData(directionAngle);
        }

        return directionAngle;
    }

    private void UpdateTargetRotationData(float targetAngle)
    {
        currentTargetRotation.y = targetAngle;
        dampedTargetRotationPassedTime.y = 0f;
    }
    private void RotateTowardsTargetRotation()
    {
        float currentYangle = rb.rotation.eulerAngles.y;

        if (currentYangle == currentTargetRotation.y)
        {
            return;
        }
        float smoothedYAngle = Mathf.SmoothDampAngle(currentYangle, currentTargetRotation.y, ref dampedTargetRotationCurrentVelocity.y, timeToReachTargetRotation.y - dampedTargetRotationPassedTime.y);
        dampedTargetRotationPassedTime.y += Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0f, smoothedYAngle, 0f);

        rb.MoveRotation(targetRotation);

    }

    private float AddCameraRotationToAngle(float directionAngle)
    {
        directionAngle += cameraTransform.eulerAngles.y;

        if (directionAngle > 360f)
        {
            directionAngle -= 360f;
        }

        return directionAngle;
    }

    private static float GetDirectionAngle(Vector3 direction)
    {
        float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (directionAngle < 0f)
        {
            directionAngle += 360f;
        }

        return directionAngle;
    }
    #endregion

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            
            rb.linearVelocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemy.Add(other.gameObject);
        }
        
        if (other.CompareTag("TempHurt"))
        {   
            if(targetEnemy)
            {
                if (targetEnemy.GetComponent<OldEnemy>()&& Vector3.Distance(targetEnemy.transform.position, this.transform.position) < 5f)
                {
                    DamageText dmgText = Instantiate(damageText, this.transform).GetComponent<DamageText>();
                    dmgText.damage = targetEnemy.GetComponent<OldEnemy>().attack;
                    currentHP -= targetEnemy.GetComponent<OldEnemy>().attack;
                }
            }
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy.Remove(other.gameObject);
        }

        
    }
}
