using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerPos;

    private void Update() 
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y,-1);
    }
}
