using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Player Player;
    /// <summary>
    /// Abstand Kamera zum Spieler
    /// </summary>
    private Vector3 offsetMovement = new Vector3(0, 5, -2.36f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    /// <summary>
    /// Ahmt die Bewegungen mit einem Abstand von <see cref="offsetMovement"/> des Spielers nach
    /// </summary>
    void Movement()
    {
        //Bewegungsvektor berechnen
        Vector3 movement = Player.transform.position + offsetMovement;

        //Kameraposition anpassen
        transform.position = movement;
    }
}
