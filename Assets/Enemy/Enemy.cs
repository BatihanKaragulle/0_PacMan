using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask whatStopsMovement;
    public Transform movePoint;
    private Vector3 directionTry = new Vector3 (1f,0f,0f);

    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        //Debug.Log(directionTry);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position)==0f)
        {
            directionTry = GetRondomDir();
            if(!Physics2D.OverlapCircle(movePoint.position + directionTry, .1f, whatStopsMovement))
                movePoint.position = movePoint.position + directionTry;              
        }
    }

    private Vector3 GetRondomDir(){
        Vector3[] ListVector =  {new Vector3(-1f,0f,0f),new Vector3(0f,1f,0f),new Vector3(1f,0,0f),new Vector3(0f,-1f,0f)};
        int randomIndex = Random.Range(0,ListVector.Length);
        return ListVector[randomIndex];
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("trigerlandim");
        Debug.Log(Physics2D.OverlapCircle(movePoint.position + directionTry, .1f, whatStopsMovement));
        if (other.gameObject.tag == "turnpoint")
        {
            Debug.Log("turnPoint");
            while (Physics2D.OverlapCircle(movePoint.position + directionTry, .1f, whatStopsMovement))
            {
                directionTry = GetRondomDir();
                Debug.Log(directionTry);
            }   
        }
    }
    
}
