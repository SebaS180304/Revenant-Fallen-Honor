using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trayectory : MonoBehaviour
{
    private Transform transfrom;
    private float speed;
    private int BulletDMG;
    [SerializeField] private GameObject explosssion;

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager.PlaySFX(audioManager.fireBall);
        transfrom = GetComponent<Transform>();
        speed = 0.5f;
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
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().GetHit(BulletDMG, transfrom.position);
            Destroy(gameObject);
            Instantiate(explosssion, transfrom.position, transfrom.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag != "Player" ){
			Destroy(gameObject);
            Instantiate(explosssion, transfrom.position, transfrom.rotation);
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
