using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 3){
            transform.parent.GetComponent<Player_Mov>().Grounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.layer == 3){
            transform.parent.GetComponent<Player_Mov>().Grounded(false);
        }
    }

    // Update is called once per frame
    private void Start() {
        
    }
}