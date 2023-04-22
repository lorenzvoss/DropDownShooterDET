using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject slime;
    public GameObject turtle;
    public GameObject player;
    public float spawnRate;
    public int maxSpawnCount;
    public float spawnRadius;

    private System.Random rnd = new System.Random();
    private int spawnCount;

    // Update is called once per frame
    void Update()
    {
        if(rnd.Next(0,100)==1 && spawnCount <= maxSpawnCount)
        {
            spawnSlime();
            spawnCount++;
        }
    }

    public void spawnSlime()
    {
        GameObject newSlime = Instantiate(slime, player.transform.position + new Vector3(rnd.Next(-10,10), 0, rnd.Next(-10,10)), Quaternion.identity);
        Vector3 direction = transform.position - newSlime.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        newSlime.transform.rotation = rotation;
    }

}