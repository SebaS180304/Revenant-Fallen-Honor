using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject Player;

    private void Awake()
    {
        Player = GameObject.Find("Player");

    }
    private void Start()
    {
        setMaxHealth(Player.GetComponent<Player_Mov>().MAX_HEALTH);
    }
    private void FixedUpdate()
    {
        setHealth(Player.GetComponent<Player_Mov>().GetHealth());

    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void setHealth(int health)
    {
        slider.value = health;
    }
}
