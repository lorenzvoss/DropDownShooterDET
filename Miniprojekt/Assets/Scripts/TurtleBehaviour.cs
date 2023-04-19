using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
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
    }
}
