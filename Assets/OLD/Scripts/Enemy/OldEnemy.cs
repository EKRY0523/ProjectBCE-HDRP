using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OldEnemy : MonoBehaviour
{

    [SerializeField]CharacterHolder character;
    [SerializeField] GameObject damageText;
    [SerializeField] GameObject hpBar;
    public Animator anim;
    public float distance;
    public float stopValue = 1;
    bool isDead = false;

    public bool aggrod;
    Vector3 lookAtTarget;
    Quaternion lookAtRotation;

    public float attack;
    public float defense;
    public float originalHp;
    public float hp;

    public Rigidbody rb;

    public bool isDoingAction;
    
    [Header("State Group Parameter Names")]
    
    [Header("Grounded Parameter Names")]
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string deathParameterName = "Die";

    [Header("Combat Parameter Names")]
    [SerializeField] private string Chain1ParameterName = "Attack1";
    [SerializeField] private string Chain2ParameterName = "Attack2";
    [SerializeField] private string Chain3ParameterName = "Attack3";

    public int IdleParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int DieParameterHash { get; private set; }

    public int Chain1ParameterHash { get; private set; }
    public int Chain2ParameterHash { get; private set; }
    public int Chain3ParameterHash { get; private set; }


    public void Initialize()
    {
        hp = character.baseMaxHP;
        originalHp = character.baseMaxHP;
        defense = character.baseDef;
        attack = character.baseATK;

        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        DieParameterHash = Animator.StringToHash(deathParameterName);

        Chain1ParameterHash = Animator.StringToHash(Chain1ParameterName);
        Chain2ParameterHash = Animator.StringToHash(Chain2ParameterName);
        Chain3ParameterHash = Animator.StringToHash(Chain3ParameterName);
    }
    private void Awake()
    {
        anim =GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        Initialize();
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        hpBar.GetComponentInChildren<Slider>().value = hp / originalHp;
    }
    private void FixedUpdate()
    {
        distance = Vector3.Distance(OldPlayer.instance.gameObject.transform.position, this.transform.position);
        if (aggrod == true && !isDead)
        {
            lookAtTarget = OldPlayer.instance.transform.position - this.transform.position;
            lookAtTarget.y = 0;
            lookAtRotation = Quaternion.LookRotation(lookAtTarget);
            this.transform.rotation = lookAtRotation;
            if (anim.GetBool("Run"))
            {
                if(distance > 3f)
                {
                    rb.AddForce((transform.forward * 7f + -transform.up) * stopValue, ForceMode.VelocityChange);

                    rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, 7f * Time.deltaTime);
                }
                else
                {
                    
                }
                
            }
            //else if(!isDoingAction)
            //{
            //    lookAtRotation = Quaternion.LookRotation(lookAtTarget);
            //    this.transform.rotation = lookAtRotation;
            //}
            
        }
        
    }
    public void startAnim(int animationHash)
    {
        anim.SetBool(animationHash, true);
    }

    public void stopAnim(int animationHash)
    {
        anim.SetBool(animationHash, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDead)
        {
            if (distance > 15f)
            {
                aggrod = true;
                startAnim(RunParameterHash);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && !isDead)
        {
            if (distance > 3f && !isDoingAction)
            {
                stopAnim(IdleParameterHash);
                stopAnim(Chain1ParameterHash);
                stopAnim(Chain2ParameterHash);
                stopAnim(Chain3ParameterHash);
                startAnim(RunParameterHash);

                isDoingAction = true;

                StartCoroutine(isInAction(2f));
            }
            if(distance >= 1f && distance <= 2f && !isDoingAction)
            {
                stopAnim(IdleParameterHash);
                startAnim(Chain1ParameterHash);
                stopAnim(Chain2ParameterHash);
                stopAnim(Chain3ParameterHash);
                stopAnim(RunParameterHash);

                attack = 150;
                isDoingAction = true;

                StartCoroutine(isInAction(5f));
            }
            if(distance >= 0.1f && distance <= 1.1f && !isDoingAction)
            {
                stopAnim(IdleParameterHash);
                stopAnim(Chain1ParameterHash);
                startAnim(Chain2ParameterHash);
                stopAnim(Chain3ParameterHash);
                stopAnim(RunParameterHash);

                attack = 100;
                isDoingAction = true;

                StartCoroutine(isInAction(3f));
            }
            if(distance>=2f && distance <= 3f && !isDoingAction)
            {
                stopAnim(IdleParameterHash);
                stopAnim(Chain1ParameterHash);
                stopAnim(Chain2ParameterHash);
                startAnim(Chain3ParameterHash);
                stopAnim(RunParameterHash);
                attack = 50;
                isDoingAction = true;

                StartCoroutine(isInAction(2f));
            }

            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
    public void TakeDamage(float damage)
    {
        float takenDamage = damage - defense;
        hp-=takenDamage;

        //Destroy(Instantiate(damageText, this.transform), 0.5f);
        DamageText dmgText = Instantiate(damageText, this.transform).GetComponent<DamageText>();
        dmgText.damage = takenDamage;
        //dmgText.GetComponent<TextMeshProUGUI>().text = takenDamage.ToString();
        //Destroy(dmgText, 0.5f);
        
        //damageText.GetComponent<TextMeshProUGUI>().text = takenDamage.ToString();

        if (takenDamage > hp)
        {
            
            doUponDeath();
            
        }
    }

    public void doUponDeath()
    {
        startAnim(DieParameterHash);
        isDead = true;
        this.gameObject.tag = "Untagged";
        OldPlayer.instance.targetEnemy = null;
        OldPlayer.instance.enemy.Remove(this.gameObject);
        OldPlayer.instance.experience += character.exp;
        Destroy(this.gameObject,3f);
    }

    IEnumerator isInAction(float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        stopAnim(IdleParameterHash);
        stopAnim(Chain1ParameterHash);
        stopAnim(Chain2ParameterHash);
        stopAnim(Chain3ParameterHash);
        stopAnim(RunParameterHash);

        isDoingAction = false;
    }
}
