using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBalloonShoot : MonoBehaviour {
    public GameObject balloon;
    public bool testRemove = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(testRemove)
        {
            RemoveBalloon();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            testRemove = true;
            RemoveBalloon();
        }
    }

    void RemoveBalloon()
    {
        Debug.Log("JA RAAK! ballooon");
        Destroy(GameObject.FindWithTag("GeoSphere01"));
        Destroy(balloon);
        balloon.active = false;
    }
}
