using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_OnTrigger : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other) 
        {
            Debug.Log("I ate food!");
        }
}
