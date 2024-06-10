using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Being
{
    public float MAX_STAMINA = 18;
    public float MAX_MANA = 10;
    private float respawn_time = 3f;
    public float stamina;
    private float dStamina;
     [SerializeField]  
    private float count;
    private float Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public float mana;
    private float Mana{
        get{return mana;}
        set{mana = value;}
    }

    //Components
    private Transform transform;
    private AudioManager audioManager;
    private Controls control;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        count = 0;
        MAX_HEALTH = 45;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        control = GetComponent<Controls>();
        transform = GetComponent<Transform>();
    }
    void Start()
    {
        health = MAX_HEALTH;
        Stamina = MAX_STAMINA;
        mana = MAX_MANA;
        dStamina = stamina;
        spawnpoint = transform.position;
    }

    void Update(){
        StaminaRegen();
    }

    public void getHit(int DMG)
    {
        audioManager.PlaySFX(audioManager.hitting);
        health -= DMG;
        if (health <= 0)
        {
            Dead();
        }
    }

    
    private void Dead()
    {
        audioManager.PlaySFX(audioManager.death);
        control.CanMove = false;
        animator.SetBool("Dead", true);
        //Start all Coroutine(Respawn());
    }
    private void StaminaRegen(){
        float dif = stamina - dStamina;
        if(dif == 0){
            count += Time.fixedDeltaTime;
        }
        else if(dif < 0){
            count = 0;
        }
        if(count > 5f && stamina < MAX_STAMINA){
            stamina += 0.1f;
        }
        
        dStamina = stamina;
    }

    public override IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawn_time);
        transform.position = spawnpoint;
        health = MAX_HEALTH;
        stamina = MAX_STAMINA;
        control.CanMove = true;
        animator.SetBool("Dead", false);
    }
    public int  GetHealth()
    {
        return health;
    }
}
