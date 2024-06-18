using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private int type;
    [SerializeField] private bool destroyable;
    

    private AudioManager audioManager;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")){    
            if( type == 1){
                player.GetComponent<Player>().GetHealed(15);
            }else{
                player.GetComponent<Player>().GetManaed(4);
            }
            if(destroyable){
                Destroy(gameObject);
            }
            else{
                gameObject.SetActive(false);
            }
        }
    }
}
