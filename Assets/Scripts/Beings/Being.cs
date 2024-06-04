using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour
{
    [SerializeField]
    public int MAX_HEALTH;
    protected int health;
    protected Vector3 spawnpoint;
    protected Quaternion orient;

    public virtual void GetHit(int Damage)
    {
    }

    public void GetHealed(int Heal)
    {
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
        yield return new WaitForSeconds(0f);
    }

    public void DontFall()
    {
        gameObject.GetComponent<Transform>().rotation = orient;
    }
}
