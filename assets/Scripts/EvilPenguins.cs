using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPenguins : MonoBehaviour {
    public float speed;
    public Transform PlayerModel;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerModel.position, step);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
