using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //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
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        Movement();
    }
    

    void Movement(){
        
        //Bewegungsvektor berechnen
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        Debug.Log(movement.ToString());

        //Blickrichtung vom Spieler anpassen
        if(movement != Vector3.zero){
            transform.rotation = Quaternion.LookRotation(movement);
        }

        //Spielerposition anpassen
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
