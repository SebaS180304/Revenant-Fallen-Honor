using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    private float dash;

    //Constants
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float JForce = 50f;
    private float smoth = 0.2f;

    //status
    [SerializeField]
    private bool CanJump;

    //Components
    private Rigidbody2D RB2D;
    private Player playerST;
    private AudioManager audioManager;

    void Start(){
        dash = 1;
        CanJump = true;

    }    
    void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();   
        playerST = GetComponent<Player>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
 
    
    public void Walk(float move)
    {
        Vector3 VObjective = new Vector2(move * speed*dash, RB2D.velocity.y);
        RB2D.velocity = Vector3.SmoothDamp(RB2D.velocity, VObjective, ref velocity, smoth);

    }
    public void Jump(bool move)
    {
        if (move && CanJump)
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, JForce);
            audioManager.PlaySFX(audioManager.jumping);
        }

    }

    public void Grounded(bool IG)
    {
        CanJump = IG;
    }

    public void Dash(bool move , float xMov){
        if(CanJump && move && playerST.stamina > 0.1 && xMov!=0){
            dash = 1.8f;
            GetComponent<Animator>().SetBool("Dashing", true);
            playerST.stamina -= 0.1f;
        }
        else{
            dash = 1f;
            GetComponent<Animator>().SetBool("Dashing", false);
        }

    }
}

