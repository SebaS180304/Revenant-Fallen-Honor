using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            GetComponentInParent<Boss>().setPlayer(other.gameObject);
            Debug.Log(other.gameObject);
        }
    }
}
