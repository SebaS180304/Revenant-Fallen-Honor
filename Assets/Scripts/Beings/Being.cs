using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour
{
    [SerializeField]
    public int MAX_HEALTH;
    [SerializeField]
    protected int health;
    protected bool inbulnerable;
    public Vector3 spawnpoint;
    protected AudioManager audioManager;
    public virtual void GetHit(int Damage, Vector2 direction)
    {

    }
    public virtual void GetHit(int Damage, Vector2 direction, int knockback){}

    public void GetHealed(int Heal)
    {
        audioManager.PlaySFX(audioManager.health);
        if (health + Heal > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }
        else
        {
            health += Heal;
        }
    } 


    public int  GetHealth()
    {
        return health;
    }

    public IEnumerator Inbulnerable(float time){

        yield return new WaitForSeconds(time);
        inbulnerable = false;
    }
}
