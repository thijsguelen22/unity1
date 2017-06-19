using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeadsetToBody : MonoBehaviour {
    public Transform Camera;
    public Transform Pos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera.position = new Vector3(Camera.position.x, Pos.position.y, Camera.position.z);

    }
}
