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
    //constants
    private Vector3 velocity = Vector3.zero;

    //Components
    private Transform transform;
    private AudioManager audioManager;
    private Rigidbody2D RB2D;
    private Controls control;
    private Animator animator;
    void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        count = 0;
        MAX_HEALTH = 45;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        control = GetComponent<Controls>();
        transform = GetComponent<Transform>();
    }
    void Start()
    {
        inbulnerable = false;
        health = MAX_HEALTH;
        Stamina = MAX_STAMINA;
        mana = MAX_MANA;
        dStamina = stamina;
        spawnpoint = transform.position;
    }

    void Update(){
        StaminaRegen();
    }

    public override void GetHit(int DMG, Vector2 direction)
    {
        Vector2 origin = transform.position;
        Vector2 vectorU = (origin-direction).normalized;
        if(! inbulnerable){
            audioManager.PlaySFX(audioManager.hitting);
            health -= DMG;
            if (health <= 0)
            {
                Dead();
            }else{
                RB2D.AddForce(vectorU*100, ForceMode2D.Impulse  );
                animator.SetTrigger("Hurt");
            }
            StartCoroutine(Inbulnerable());

        }
        
        
    }

    
    private void Dead()
    {
        audioManager.PlaySFX(audioManager.death);
        animator.SetBool("Dead", true);
        RB2D.velocity = Vector3.SmoothDamp(RB2D.velocity, new Vector2(0,RB2D.velocity.y), ref velocity, 0.2f);
        StartCoroutine(Respawn());
    }
    private void StaminaRegen(){
        float dif = stamina - dStamina;
        if(dif == 0){
            count += Time.fixedDeltaTime;
        }
        else if(dif < 0){
            count = 0;
        }
        if(count > 15f && stamina < MAX_STAMINA){
            stamina += 0.5f * Time.fixedDeltaTime;
        }
        
        dStamina = stamina;
    }

    public override IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawn_time);
        RB2D.velocity = new Vector2(0,0);
        transform.position = spawnpoint;
        health = MAX_HEALTH;
        stamina = MAX_STAMINA;
        mana = MAX_MANA;
        inbulnerable = false;
        animator.SetBool("Dead", false);
    }


    public void SetInbulnerable(bool state){
        inbulnerable = state;
    }
    


}
