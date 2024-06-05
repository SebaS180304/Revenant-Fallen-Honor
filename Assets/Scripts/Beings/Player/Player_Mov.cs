using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Being
{
    //inputs
    private float xMov;
    private bool yMov;
    private bool jump; // variable intermedia entre yMov, es como un "en espera"
                       // Sin ella el salto seria inpresiso.
                       //Mid values
    private Vector3 velocity = Vector3.zero;
    //Consts Mov
    [SerializeField]
    private float speed = 5000f;
    [SerializeField]
    private float JForce = 50f;
    public float MAX_STAMINA = 18;
    public float MAX_MANA = 10;
    private float respawn_time = 3f;
    public float stamina;
    private float dStamina;
     [SerializeField]  
    private float count;
    private int dash;
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
    private float smoth = 0.3f;
    //Bools Mov
    private bool CanMove = true;
    [SerializeField]
    private bool CanJump = true;
    private bool rightF = true;
    //Components
    private Rigidbody2D RB2D;
    private Transform transform;
    private SpriteRenderer spriteRender;
    private Transform AttackPos;




    // Start is called before the first frame update
    void Awake()
    {
        count = 0;
        MAX_HEALTH = 45;
        RB2D = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        spriteRender = GetComponent<SpriteRenderer>();
        AttackPos = transform.GetChild(1);
    }
    void Start()
    {
        CanMove = true;
        health = MAX_HEALTH;
        Stamina = MAX_STAMINA;
        mana = MAX_MANA;
        dStamina = stamina;
        spawnpoint = transform.position;
        orient = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused){
            dash = (Input.GetKey(KeyCode.LeftShift) && stamina > 0.1) ? 3 : 1;
            if (CanMove)
            {
                xMov = Input.GetAxisRaw("Horizontal") * dash;
                yMov = Input.GetButtonDown("Jump");
                jump = yMov ? true : jump;
            }
            animate();
        }
    }
    void FixedUpdate()
    {
        StaminaRegen();
        Walk(xMov * Time.fixedDeltaTime);
        Jump(jump);
        jump = false;

    }
    void animate()
    {
        if (xMov != 0)
        {
            ///animate run
            if(rightF && xMov < 0){
                transform.Rotate(0f,180f,0f);
                rightF = false;
            }
            if(!rightF && xMov > 0){
                transform.Rotate(0f,180f,0f);
                rightF = true;
            }
        }
        else
        {
            //animate Idle
        }
    }
    void Walk(float move)
    {
        Vector3 VObjective = new Vector2(move * speed, RB2D.velocity.y);
        RB2D.velocity = Vector3.SmoothDamp(RB2D.velocity, VObjective, ref velocity, smoth);
        if (xMov != 0 && dash != 1)
        {
            stamina -= 0.1f;
        }

    }
    void Jump(bool move)
    {
        if (move && CanJump)
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, JForce);
        }

    }

    public void getHit(int DMG)
    {
        health -= DMG;
        if (health <= 0)
        {
            Dead();
        }
    }

    public void Grounded(bool IG)
    {
        CanJump = IG;
    }
    private void Dead()
    {
        CanMove = false;
        //animacion muerte
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
        if(count > 3f && stamina < MAX_STAMINA){
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
        CanMove = true;
    }
    public bool GetCanMove()
    {
        return CanMove;
    }
    public int  GetHealth()
    {
        return health;
    }
}
