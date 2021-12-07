using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool active = true;

    public bool getActive()
    {
        return active;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("I ate food!");

        active = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(!getActive())
        {
            Destroy(this.gameObject);
        }
    }
}