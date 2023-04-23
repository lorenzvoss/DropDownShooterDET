using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float damage;
    public float health;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame   
    void Update()
    {
        moveTowardPlayer();
    }

    public void CalculateRotation()
    {

    }

    public void moveTowardPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

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
            
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.kills += 1;
    }
}
