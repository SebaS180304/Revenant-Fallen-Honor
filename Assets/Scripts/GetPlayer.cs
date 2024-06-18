using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Boss boss;
    void Start()
    {
        boss = GameObject.Find("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            boss.setPlayer(other.gameObject);
        }
    }
}
