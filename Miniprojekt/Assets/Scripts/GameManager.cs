using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int kills = 0;
    public Boolean gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    private void Awake()
    {
        Instance = this;
    }
}
