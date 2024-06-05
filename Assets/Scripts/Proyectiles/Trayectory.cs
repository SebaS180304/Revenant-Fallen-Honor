using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trayectory : MonoBehaviour
{
    private Transform transfrom;
    private int speed;
    private int BulletDMG;

    // Start is called before the first frame update
    void Start()
    {
        transfrom = GetComponent<Transform>();
        speed = 2;
        StartCoroutine(AutoDestruction());
        
    }

    // Update is called once per frame
    void Update()
    {
        transfrom.position += transfrom.right * speed * Time.fixedDeltaTime;
    }
    void FixedUpdate(){

    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Finded");
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Being>().GetHit(BulletDMG);
            Debug.Log("Perforated");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag != "Player"){
			Destroy(gameObject);
		}
    }
    public void setBulletDMG(int DMG){
        BulletDMG = DMG;
    }
    private IEnumerator AutoDestruction(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
