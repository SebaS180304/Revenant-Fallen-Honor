using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    private float lerpspeed = 0.005f;
    [SerializeField] private GameObject enemy;
    private void Start()
    {
        setMaxHealth(enemy.GetComponent<Enemy>().MAX_HEALTH);
    }
    private void Update()
    {
        if (enemy != null)
        {
            setHealth(enemy.GetComponent<Enemy>().GetHealth());
            if (healthSlider.value != (enemy.GetComponent<Enemy>().GetHealth()))
            {
                healthSlider.value = (enemy.GetComponent<Enemy>().GetHealth());
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                enemy.GetComponent<Enemy>().GetHit(5, new Vector2(0, 0));
            }
            if (healthSlider.value != easeHealthSlider.value)
            {
                easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, enemy.GetComponent<Enemy>().GetHealth(), lerpspeed);
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
