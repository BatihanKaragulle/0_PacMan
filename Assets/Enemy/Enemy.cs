using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask whatStopsMovement;
    public Transform movePoint;
    private Vector3 directionTry;

    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        directionTry = new Vector3 (1f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position)==0f)
        {
            if(Mathf.Abs(directionTry[0])==1)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + directionTry, .1f, whatStopsMovement))
                    movePoint.position = movePoint.position + directionTry;              
            }


            if(Mathf.Abs(directionTry[1])==1)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + directionTry, .1f, whatStopsMovement))
                    movePoint.position = movePoint.position + directionTry;
            }
        }
    }

    private Vector3 GetRondomDir(){
        Vector3[] ListVector =  {new Vector3(-1f,0f,0f),new Vector3(0f,1f,0f),new Vector3(1f,0,0f),new Vector3(0f,-1f,0f)};
        int randomIndex = Random.Range(0,ListVector.Length);
        return ListVector[randomIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "turnpoint")
        {
            while (!Physics2D.OverlapCircle(movePoint.position + directionTry, .1f, whatStopsMovement)||!Physics2D.OverlapCircle(movePoint.position + directionTry, .1f, whatStopsMovement))
            {
                directionTry = GetRondomDir();
            }
            
        }
    }
}
