using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy enemy;
    private Transform transform;
    private int DMG;
    private int AttackForce;
    private void Awake() {
        enemy = GetComponentInParent<Enemy>();
        transform = GetComponentInParent<Transform>();    
        DMG = enemy.getDMG();
    }
    void Start()
    {
        AttackForce = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        try{
            other.gameObject.GetComponent<Player>().GetHit(DMG, transform.position, AttackForce);
        }catch(Exception e){
            Debug.Log("NoPlayerFound");
        }
    }
}
