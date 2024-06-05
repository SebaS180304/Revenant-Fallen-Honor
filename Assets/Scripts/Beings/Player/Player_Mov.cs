using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : Being
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
    [SerializeField]
    private float MAX_STAMINA = 18;
    private float respawn_time = 3f;
    public float stamina;
    private int dash;
    private float Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    private float smoth = 0.3f;
    //Bools Mov
    private bool CanMove = true;
    [SerializeField]
    private bool CanJump = true;
    //Components
    private Rigidbody2D RB2D;
    private Transform transform;
    private SpriteRenderer spriteRender;
    private Transform AttackPos;




    // Start is called before the first frame update
    void Awake()
    {
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
        spawnpoint = transform.position;
        orient = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused){
            DontFall();
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
        Walk(xMov * Time.fixedDeltaTime);
        Jump(jump);
        jump = false;

    }
    void animate()
    {
        if (xMov > 0)
        {
            //animate
            if (spriteRender.flipX)
            {
                AttackPos.localPosition = new Vector3(-AttackPos.localPosition.x, AttackPos.localPosition.y, 0);
            }
            spriteRender.flipX = false;

        }
        else if (xMov < 0)
        {
            //animate
            if (!spriteRender.flipX)
            {
                AttackPos.localPosition = new Vector3(-AttackPos.localPosition.x, AttackPos.localPosition.y, 0);
            }
            spriteRender.flipX = true;
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
        StartCoroutine(Respawn());
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
