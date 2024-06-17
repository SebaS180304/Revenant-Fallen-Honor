using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject item;
    public GameObject player;

    private AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && item.CompareTag("Health")){
            player.GetComponent<Player>().GetHealed(15);
            gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Player") && item.CompareTag("Mana")){
            player.GetComponent<Player>().GetManaed(4);
            gameObject.SetActive(false);
        }
    }
}
