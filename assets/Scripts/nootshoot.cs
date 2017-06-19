using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nootshoot : MonoBehaviour {
    public GameObject pingu;
    public AudioSource noot;
    // Use this for initialization
    void Start () {
        noot = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            noot.Play();
            Debug.Log("JA RAAK! lamp");
            pingu.active = false;
        }
    }
}
