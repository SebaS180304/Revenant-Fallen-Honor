using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    private float lerpspeed = 0.005f;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");

    }
    private void Start()
    {
        setMaxHealth(player.GetComponent<Player>().MAX_HEALTH);
    }
    private void Update()
    {
        if(player != null){
            setHealth(player.GetComponent<Player>().GetHealth());
            if (healthSlider.value != (player.GetComponent<Player>().GetHealth()))
            {
                healthSlider.value = (player.GetComponent<Player>().GetHealth());
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.GetComponent<Player>().GetHit(5, new Vector2(0,0));
            }
            if (healthSlider.value != easeHealthSlider.value)
            {
                easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, player.GetComponent<Player>().GetHealth(), lerpspeed);
            };
        }
    }

    public void setMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        easeHealthSlider.maxValue = health;
        healthSlider.value = health;
        easeHealthSlider.value = health;
    }
    
    public void setHealth(int health)
    {
        healthSlider.value = health;
    }
}

