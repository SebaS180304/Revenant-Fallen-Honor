using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private Transform transform;
    [SerializeField] private GameObject enemybulltet;
    private float count;
    void Start()
    {
        count =0;
        transform = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        count += Time.deltaTime;
        if(count > 0.05){
            count = 0;
            Instantiate(enemybulltet, transform.position, transform.rotation);
        }
    }
}
