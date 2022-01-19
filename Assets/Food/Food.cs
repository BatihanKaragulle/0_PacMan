using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool active = true;

    public Movement player;
    int HealthPoints;

    public bool getActive()
    {
        return active;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(player!=null && player.getcanvalue()<=4 && !other.CompareTag("enemy")){
            //Debug.Log("I ate food!");
            active = false;
        }
    }
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
