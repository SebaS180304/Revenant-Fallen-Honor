using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    // Start is called before the first frame update
    private Decision enemy;
    void Start()
    {
        enemy = GetComponentInParent<Decision>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            enemy.setPlayer(other.gameObject.GetComponent<Transform>());
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            enemy.setPlayer(null);
        }
    }
}
