using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private  List<GameObject> plataformas;
    
    private Boss boss;
    private void Start() {
        boss = GameObject.Find("Boss").GetComponent<Boss>();
        boss.OnFire += Change;
    }

    private void Change(object sender, EventArgs e){
        foreach (GameObject plataforma in plataformas){
            plataforma.SetActive(!plataforma.activeSelf);
        }
    }
}
