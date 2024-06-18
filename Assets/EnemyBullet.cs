using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    [SerializeField] private float speed;
    [SerializeField] private GameObject effect;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AutoDestruction());
        transform.position+= (transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" ){
            other.gameObject.GetComponent<Player>().GetHit(3, transform.position, 5);
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag != "Enemy" ){
			Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }

    }

    private IEnumerator AutoDestruction(){
        yield return new WaitForSeconds(5f);
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
