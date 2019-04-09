using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "karakter")
        {
            karakter.halka_sayisi++; //Toplanan puanı arttırır
            GameObject.Destroy(this.gameObject); //Alınan halkayı yok eder.
        }
    }
}
