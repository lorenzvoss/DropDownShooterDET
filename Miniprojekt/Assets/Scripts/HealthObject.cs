using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    private float inGameTime;

    private void Start() 
    {
        inGameTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 40f * Time.deltaTime);
        inGameTime  += Time.deltaTime;

        if(inGameTime > 10f)
        {
            Destroy(this.gameObject);
        }
    }
}
