using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    Rigidbody2D Body;
    float horX;
    float vertY;

    public float runSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ola");
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horX = Input.GetAxis("Horizontal");
        vertY = Input.GetAxis("Vertical");


        Debug.Log(horX);
    }

    private void FixedUpdate() {
        Body.velocity = new Vector2(horX * runSpeed, vertY * runSpeed);
    }
}
