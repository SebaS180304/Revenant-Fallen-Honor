using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour
{
    [SerializeField]
    public int MAX_HEALTH;
    protected int health;
    protected bool inbulnerable;
    protected Vector3 spawnpoint;
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

    public virtual IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.1f);
        if(GetComponent<Animator>() != null){
             GetComponent<Animator>().SetBool("Dead", false);
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
