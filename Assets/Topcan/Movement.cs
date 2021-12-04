using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void Update()
    {
       

    }

    void FixedUpdate() 
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float xmovement = inputX * speed;
        float ymovement = inputY * speed;

        Vector2 movement= new Vector2(xmovement, ymovement);

        movement *= Time.deltaTime;

         transform.Translate(movement);

    }
}
