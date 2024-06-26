using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controls : MonoBehaviour
{
    //Inputs
    private float xMov;
    private bool yMov;
    private bool dashing;
    private bool jump; //Inter Value
    private bool attack; //Inter Value
    private bool attacking;
    private bool fire;
    private bool firing; // Inter Value

    //States
    private bool rightF;
    
    public bool CanMove;


    // Components
    private Transform position;
    private Movement movement;
    private Animator animator;
    private Rigidbody2D RB2D;
    private Attacks attacks;

    private void Awake() {
        position = GetComponent<Transform>();
        movement = GetComponent<Movement>();
        attacks = GetComponentInChildren<Attacks>();
        animator = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();   
    }

    void Start()
    {
        xMov = 0;
        jump = false;
        rightF = true;
        CanMove = true;
    }


    private void Update(){
        if (!PauseMenu.isPaused){ 
            if (CanMove)
            {
<<<<<<< Updated upstream
                attacking = Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.JoystickButton7);
                firing = Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.JoystickButton6);
                dashing = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton1);
                xMov = Input.GetAxisRaw("Horizontal");
                yMov = (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0)) ;
=======
                attacking = Input.GetKey(KeyCode.Mouse0)|| Input.GetKey(KeyCode.JoystickButton5);
                firing = Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.JoystickButton4);
                dashing = Input.GetKey(KeyCode.LeftShift) ||  Input.GetKey(KeyCode.JoystickButton1);
                xMov = Input.GetAxisRaw("Horizontal");
                yMov = Input.GetKey(KeyCode.Space) ||Input.GetKey(KeyCode.JoystickButton0);
>>>>>>> Stashed changes
                //Al ser el tipo get keydown, y el update es mas rapido que el fixedUp, hace que reciba el input, pero no haga la accion al instante
                //Por eso es que tiene que tener variebles intermedias
                jump = yMov ? true : jump;
                attack = attacking ? true : attack;
                fire = firing ? true : fire;

            }
            else {
                xMov = 0f;
            }
        }
    }

    private void FixedUpdate() {
            movement.Dash(dashing, xMov);
            movement.Walk(xMov * Time.fixedDeltaTime);
            movement.Jump(jump);
            attacks.SwordAttack(attack,fire);
            jump = false;
            attack = false;
            fire = false;

            Animate();
    }

    private void Animate()
    {
        if (xMov != 0)
        {
            animator.SetBool("Walking", true);
            if(rightF && xMov < 0){
                position.Rotate(0f,180f,0f);
                rightF = false;
            }
            if(!rightF && xMov > 0){
                position.Rotate(0f,180f,0f);
                rightF = true;
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        animator.SetFloat("AirSpeedY",  MathF.Round(RB2D.velocity.y, 1, MidpointRounding.ToEven));
    }

}
