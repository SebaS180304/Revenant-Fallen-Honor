using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] enemys;
    private GameObject[] items;
    private Player player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(enemys == null){
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
        }
        if(items == null){
            items = GameObject.FindGameObjectsWithTag("item");
        }
    }
    void Start()
    {
        player.onDead += StartAll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartAll(object sender, EventArgs e){
        foreach(GameObject enemy in enemys){
            enemy.SetActive(true);
            enemy.GetComponent<Enemy>().Respawn();
        }
        foreach(GameObject item in items){
        item.SetActive(true);
        }
        
    }
}
