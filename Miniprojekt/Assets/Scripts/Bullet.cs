using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }else if(transform.position.x < -12 || transform.position.x > 12)
        {
            Destroy(gameObject);
        }else if (transform.position.z < -8 || transform.position.z > 16)
        {

        }
    }
}
