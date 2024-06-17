using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaSlider;
    public Slider easeStaminaSlider;
    private float lerpspeed = 0.005f;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");

    }
    private void Start()
    {
        setMaxStamina(player.GetComponent<Player>().MAX_STAMINA);
    }
    private void Update()
    {
        if (player != null)
        {
            setStamina(player.GetComponent<Player>().stamina);
            if (staminaSlider.value != (player.GetComponent<Player>().stamina))
            {
                staminaSlider.value = (player.GetComponent<Player>().stamina);
            }
            if (staminaSlider.value != easeStaminaSlider.value)
            {
                easeStaminaSlider.value = Mathf.Lerp(easeStaminaSlider.value, player.GetComponent<Player>().stamina, lerpspeed);
            };
        }
    }

    public void setMaxStamina(float stamina)
    {
        staminaSlider.maxValue = stamina;
        easeStaminaSlider.maxValue = stamina;
        staminaSlider.value = stamina;
        easeStaminaSlider.value = stamina;
    }

    public void setStamina(float stamina)
    {
        staminaSlider.value = stamina;
    }
}
