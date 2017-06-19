using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByHeadset : MonoBehaviour {
    public Transform Camera;
    public Transform Neck;
    public Transform Pos;
    public Transform Hair;
    public int moveX = 0;
    public int moveY = 0;

    private float prevY = 0;

    float[] lastRot = { 0, 0, 0 };

    float[] lastRot2 = { 0, 0, 0 };
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Pos.Rotate(0, (Camera.eulerAngles.y - 90) - lastRot[1], 0, Space.Self);
        Neck.Rotate(0, Camera.eulerAngles.x - lastRot[0], Camera.eulerAngles.z - lastRot[2], Space.Self);
        lastRot[0] = Camera.eulerAngles.x;
        lastRot[1] = Camera.eulerAngles.y - 90;
        lastRot[2] = Camera.eulerAngles.z;
        Pos.position = new Vector3(Camera.position.x + moveX, Pos.position.y + moveY , Camera.position.z);
        //Camera.transform.translate = (0, 9os.position.y - prevY, 0);
        transform.Translate(Vector3.right *(Pos.position.y - prevY) * 10 * Time.deltaTime);
        prevY = Pos.position.y;
    }
}
