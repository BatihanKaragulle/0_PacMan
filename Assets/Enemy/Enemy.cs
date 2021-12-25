using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 GetRondomDir(){
        Vector2[] ListVector =  {new Vector2(-1f,0f),new Vector2(0f,1f),new Vector2(1f,0),new Vector2(0f,-1f)};
        int randomIndex = Random.Range(0,ListVector.Length);
        return ListVector[randomIndex];
    }

    private Vector2 GetRomdomPosition(){
        return startingPos + this.GetRondomDir() * Random.Range(10f,70f);
    }

    private void MoveTo(Vector2 targetPos){
        
    }
}
