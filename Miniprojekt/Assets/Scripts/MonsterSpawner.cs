using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject slime;
    public GameObject turtle;
    public GameObject player;
    public float spawnDelay;
    public int maxSpawnCount;
    public float minSpawnDistance;

    public int spawnCount;
    private bool isSpawning;

   
    void Start()
    {
        InvokeRepeating("spawnSlime", 3f, spawnDelay);
        isSpawning  = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCount >= maxSpawnCount)
        {
            CancelInvoke("spawnSlime");
            isSpawning = false;
        }
        if(!isSpawning && spawnCount < maxSpawnCount)
        {
            InvokeRepeating("spawnSlime", 0f, spawnDelay);
            isSpawning = true;
        }
    }

    public void spawnSlime()
    {
        Instantiate(slime, generateRandomSpawnpoint(), Quaternion.identity);
        spawnCount++;
    }


    public Vector3 generateRandomSpawnpoint()
    {
        GameObject ground = GameObject.Find("Ground");
        Collider groundCollider = ground.GetComponent<Collider>();

        Vector3 spawnpoint;

        do
        {
            spawnpoint = new Vector3(Random.Range(groundCollider.bounds.min.x, groundCollider.bounds.max.x), 
                                    0f, Random.Range(groundCollider.bounds.min.z, groundCollider.bounds.max.z));
        }
        while(Vector3.Distance(spawnpoint, player.transform.position) < minSpawnDistance);

        return spawnpoint;
    }

}