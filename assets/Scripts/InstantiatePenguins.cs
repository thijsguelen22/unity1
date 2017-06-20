using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePenguins : MonoBehaviour
{
    public GameObject EvilPenguin;
    public Transform[] TransformLocations;
    public float SpawnEverySeconds = 10.0f;
    public Transform PlayerModel;

    private float SpawnPoints = 0;
    private float timer = 0;
    private float timer2 = 0;
    // Use this for initialization
    void Start()
    {
        foreach (Transform value in TransformLocations)
        {
            SpawnPoints++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer > SpawnEverySeconds)
        {
            int randSpawnLoc = Mathf.RoundToInt(Random.Range(0.0f, 4.0f));
            Vector3 relativePos = PlayerModel.position - TransformLocations[randSpawnLoc].position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            GameObject.Instantiate(EvilPenguin, TransformLocations[randSpawnLoc].position, rotation);
            timer = 0;
        }

    }
}
