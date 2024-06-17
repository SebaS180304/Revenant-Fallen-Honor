using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private int type;

    private AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && type == 1){
            player.GetComponent<Player>().GetHealed(15);
            gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Player") && type == 0){
            player.GetComponent<Player>().GetManaed(4);
            gameObject.SetActive(false);
        }
    }
}
