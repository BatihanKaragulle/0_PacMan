using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool Emre = true;

    public bool emreninannesi()
    {
        return Emre;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("I ate food!");

        Emre = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!emreninannesi())
        {
            Destroy(this.gameObject);
        }
    }
}
