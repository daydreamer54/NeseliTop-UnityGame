using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    // Use this for initialization
    GameObject karakterd;
    public float mesafe,x;

	void Start ()
    {
        karakterd = GameObject.FindGameObjectWithTag("karakter");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (karakterd.GetComponent<karakter>().yerdemi)
        {
            transform.position = new Vector3(karakterd.transform.position.x+x,karakterd.transform.position.y+mesafe,transform.position.z);

        }
        else
        {
            transform.position = new Vector3(karakterd.transform.position.x + x, transform.position.y, transform.position.z);
        }
    }
}
