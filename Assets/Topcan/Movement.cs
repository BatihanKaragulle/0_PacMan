using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float speed = 30;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        transform.Translate(moveAmount,0,steerAmount);
    }
}
