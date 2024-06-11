using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaSlider;
    public Slider easeManaSlider;
    private float lerpspeed = 0.005f;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");

    }
    private void Start()
    {
        setMaxMana(player.GetComponent<Player>().MAX_MANA);
    }
    private void Update()
    {
        if (player != null)
        {
            setMana(player.GetComponent<Player>().mana);
            if (manaSlider.value != (player.GetComponent<Player>().mana))
            {
                manaSlider.value = (player.GetComponent<Player>().mana);
            }
            if (manaSlider.value != easeManaSlider.value)
            {
                easeManaSlider.value = Mathf.Lerp(easeManaSlider.value, player.GetComponent<Player>().mana, lerpspeed);
            };
        }
    }

    public void setMaxMana(float Mana)
    {
        manaSlider.maxValue = Mana;
        easeManaSlider.maxValue = Mana;
        manaSlider.value = Mana;
        easeManaSlider.value = Mana;
    }

    public void setMana(float Mana)
    {
        manaSlider.value = Mana;
    }
}
