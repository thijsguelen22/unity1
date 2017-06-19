using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boobsPhysics : MonoBehaviour
{
    public Transform leftBoob;
    public Transform rightBoob;
    private float sin;
    private float timer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sin = Mathf.Sin(timer);
        leftBoob.Translate(Vector3.up * (sin - 0.1f) / 2000, Space.World);
        rightBoob.Translate(Vector3.up * (sin - 0.1f) / 2000, Space.World);
    }
}
