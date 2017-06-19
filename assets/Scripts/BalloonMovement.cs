using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour {
    public float speed = 2f;
    public float maxRotation = 45f;
    public float startingRotation = -90;
    public GameObject balloon;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * speed) - startingRotation, 0f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            //hit.Play();
            Debug.Log("JA RAAK! ballon");
            Destroy(collision.gameObject);
            balloon.active = false;
        }
    }
}
