using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    // valores cambiables (constantes)
    private Transform attackPosition;
    [SerializeField] private float area;
    [SerializeField] private int SwordDMG;
    private int sword_cost;
    [SerializeField] private int BulletDMG;
    private int bullet_cost;
    public GameObject Bullet;
    [SerializeField] private float coolDown;
    // componentes
    private Player PM;

    //Limitadores
    private bool CanAttack;
    private bool active = false;
    AudioManager audioManager;
    private void Awake() {
        CanAttack = true;
        area = 0.8f;
        SwordDMG = 2;
        BulletDMG = 1; 
        sword_cost = 2;
        bullet_cost = 3;
        attackPosition = GetComponent<Transform>();
        PM = transform.parent.GetComponent<Player>();
        active = true;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update() {
        if(!PauseMenu.isPaused){
            if(PM.CanMove){
            if(Input.GetKeyDown(KeyCode.Mouse0) && CanAttack && PM.stamina > sword_cost){
                    audioManager.PlaySFX(audioManager.attacking);
                    SwordAttack();
                if(Input.GetKey(KeyCode.Mouse1) && PM.mana > bullet_cost){
                    StartCoroutine(BulletAttack());
                }
            }
        }
        }
    }
    private void SwordAttack(){
        PM.GetComponent<Animator>().SetTrigger("Attack1");
        PM.stamina -= sword_cost;
        CanAttack = false;
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackPosition.position, area);
        foreach(Collider2D object_ in objects){
            if(object_.CompareTag("Enemy")){
                audioManager.PlaySFX(audioManager.hitting);
                object_.GetComponent<Being>().GetHit(SwordDMG);
                Debug.Log("Hit");
            }
        }
        
        StartCoroutine(CoolDown());
    }
    private IEnumerator BulletAttack(){
        PM.mana -= bullet_cost;
        yield return new WaitForSeconds(0.21f);
        GameObject B = Instantiate(Bullet, attackPosition.position, attackPosition.rotation);
        B.GetComponent<Trayectory>().setBulletDMG(BulletDMG);

    }

    private void OnDrawGizmos() {
        if(active){
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPosition.position, area);
        }
        
    }
    private IEnumerator CoolDown(){
        yield return new WaitForSeconds(coolDown);
        CanAttack = true;
    } 
}
