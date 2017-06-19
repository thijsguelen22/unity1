using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoEnableGun : MonoBehaviour {
    public GameObject gun;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gun.active == false)
        {
            gun.active = true;
        }
	}
}
