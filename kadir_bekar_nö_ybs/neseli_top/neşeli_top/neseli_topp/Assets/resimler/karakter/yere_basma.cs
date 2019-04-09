using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yere_basma : MonoBehaviour {

    // Use this for initialization
    karakter k; //karakter nesnesini oluşturur.
    
	void Start ()
    {
        k = transform.root.GetComponent<karakter>(); // karakteri atadık.
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "zemin")
        {
            k.yerdemi = true; //Yerde olup olmadığını kontrol ettik.
        }
        
    }
}
