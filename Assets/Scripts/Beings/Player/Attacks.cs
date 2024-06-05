using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    // valores cambiables (constantes)
    private Transform attackPosition;
    [SerializeField] private float area;
    private float swordCost;
    [SerializeField] private int SwordDMG;
    private float bulletCost;
    [SerializeField] private int BulletDMG;
    
    [SerializeField] private float coolDown;
    // componentes
    private Player_Mov PM;

    //Limitadores
    private bool CanAttack;
    private bool active = false;

    private void Awake() {
        CanAttack = true;
        area = 0.5f;
        swordCost = 1;
        SwordDMG = 2;
        bulletCost = 2;
        BulletDMG = 1; 
        attackPosition = GetComponent<Transform>();
        PM = transform.parent.GetComponent<Player_Mov>();
        active = true;
    }

    private void Update() {
        if(!PauseMenu.isPaused){
            if (PM.GetCanMove())
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && CanAttack && PM.stamina > swordCost)
                {
                    SwordAttack();
                    if (Input.GetKey(KeyCode.Mouse1) && PM.stamina > bulletCost)
                    {
                        BulletAttack();
                    }
                }
            }
        }
    }
    private void SwordAttack(){
        PM.stamina -= swordCost;
        CanAttack = false;
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackPosition.position, area);
        foreach(Collider2D object_ in objects){
            if(object_.CompareTag("Enemy")){
                object_.GetComponent<Being>().GetHit(SwordDMG);
                Debug.Log("Hit");
            }
        }
        
        StartCoroutine(CoolDown());
    }
    private void BulletAttack(){
        //Initiate Bullet;
        PM.stamina -= bulletCost;
    }

    private void OnDrawGizmos() {
        if(active){
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPosition.position, area);
        }
        
    }
    private IEnumerator CoolDown(){
        Debug.Log("Attacking");
        yield return new WaitForSeconds(coolDown);
        CanAttack = true;
        Debug.Log("End");
    } 
}
