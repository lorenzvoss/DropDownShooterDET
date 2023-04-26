using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float damage;
    public float health;
    public GameObject healingObject;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame   
    void Update()
    {
        moveTowardPlayer();
        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    public void moveTowardPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        //Calculate and assign the correct rotation to face the player
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        MonsterSpawner monsterSpawner = GameObject.Find("GameManager").GetComponent<MonsterSpawner>();

        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            monsterSpawner.spawnCount = monsterSpawner.spawnCount - 1;
            if(Random.value <= 0.1f)
            {
                Instantiate(healingObject, transform.position, Quaternion.identity);
            }
        }
        
        
    }


    private void OnDestroy()
    {
        GameManager.Instance.kills += 1;
    }
}

