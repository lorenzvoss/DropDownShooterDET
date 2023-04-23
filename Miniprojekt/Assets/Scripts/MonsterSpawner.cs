using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject slime;
    public GameObject turtle;
    public GameObject player;
    public float spawnDelaySlime;
    public float spawnDelayTurtle;
    public int maxSpawnCount;
    public float minSpawnDistance;
    public int spawnCount;

    private bool isSpawning;

   
    void Start()
    {
        InvokeRepeating("spawnSlime", 2f, spawnDelaySlime);
        InvokeRepeating("spawnTurtle", 4f, spawnDelayTurtle);
        isSpawning  = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCount >= maxSpawnCount)
        {
            CancelInvoke("spawnSlime");
            CancelInvoke("spawnTurtle");
            isSpawning = false;
        }
        if(!isSpawning && spawnCount < maxSpawnCount)
        {
            InvokeRepeating("spawnSlime", 2f, spawnDelaySlime);
            InvokeRepeating("spawnTurtle", 4f, spawnDelayTurtle);
            isSpawning = true;
        }
    }

    public void spawnSlime()
    {
        Instantiate(slime, generateRandomSpawnpoint(), Quaternion.identity);
        spawnCount++;
    }

    public void spawnTurtle()
    {
        Instantiate(turtle, generateRandomSpawnpoint(), Quaternion.identity);
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