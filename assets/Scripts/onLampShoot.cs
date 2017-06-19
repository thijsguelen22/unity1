using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLampShoot : MonoBehaviour {
    public GameObject light;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            //hit.Play();
            Debug.Log("JA RAAK! lamp");
            Destroy(collision.gameObject);
            light.active = false;
        }
    }
}
