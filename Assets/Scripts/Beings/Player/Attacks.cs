using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    //Sword
    [SerializeField] private float area;
    [SerializeField] private int SwordDMG;
    private int sword_cost;
    //Bullet
    [SerializeField] private int BulletDMG;
    private int bullet_cost;
    public GameObject Bullet;
    //Constantes
    [SerializeField] private float coolDown;
    //Componentes
    private Transform attackPosition;
    private Player PM;
    AudioManager audioManager;

    //Limitadores
    private bool CanAttack;
    private bool active = false;


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


    public  void SwordAttack(bool attack, bool fire){
        if(CanAttack && PM.stamina > sword_cost && attack){
            audioManager.PlaySFX(audioManager.attacking);
            PM.GetComponent<Animator>().SetTrigger("Attack1");
            PM.stamina -= sword_cost;
            CanAttack = false;
            Collider2D[] objects = Physics2D.OverlapCircleAll(attackPosition.position, area);
            foreach(Collider2D object_ in objects){
                if(object_.CompareTag("Enemy")){
                    audioManager.PlaySFX(audioManager.hitting);
                    object_.GetComponent<Being>().GetHit(SwordDMG, attackPosition.position);
                    Debug.Log("Hit");
                }
            }
            StartCoroutine(BulletAttack(fire));
            StartCoroutine(CoolDown());

        }
    }
    public IEnumerator BulletAttack(bool fire){
        if(PM.mana > bullet_cost && fire){
            PM.mana -= bullet_cost;
            yield return new WaitForSeconds(0.21f);
            GameObject B = Instantiate(Bullet, attackPosition.position, attackPosition.rotation);
            B.GetComponent<Trayectory>().setBulletDMG(BulletDMG);
        }
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
