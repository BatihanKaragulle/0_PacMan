using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    public LayerMask whatStopsMovement;
    private Vector3 directionTry = new Vector3 (1f,0f,0f);
    private Vector3 newMovePoint;
    private bool move;
    private bool colliderPosSet;
    private Vector3 colliderPos;

    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        newMovePoint = transform.position;
        move = true;
        Random.InitState(System.DateTime.Now.Millisecond);
        //Debug.Log(directionTry);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, newMovePoint, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, newMovePoint) == 0f)
            {
                //directionTry = GetRondomDir();
                if (!Physics2D.OverlapCircle(newMovePoint + directionTry, .1f, whatStopsMovement))
                    newMovePoint += directionTry;
            }
        }
        else if(colliderPosSet && Vector3.Distance(transform.position, newMovePoint) == 0f)
        {
            directionTry = GetRondomDir();
            while (Physics2D.OverlapCircle(transform.position + directionTry, .001f, whatStopsMovement))
            {
                directionTry = GetRondomDir();
                Debug.Log(directionTry);
            }

            colliderPosSet = false;
            move = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, newMovePoint, speed * Time.deltaTime);
        }
    }

    private Vector3 GetRondomDir(){
        Vector3[] ListVector =  {new Vector3(-1f,0f,0f),new Vector3(0f,1f,0f),new Vector3(1f,0,0f),new Vector3(0f,-1f,0f)};
        int randomIndex = Random.Range(0,ListVector.Length);
        return  ListVector[randomIndex];
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigerlandim");
        if (other.gameObject.tag != "turnpoint") return;
        move = false;
        Debug.Log("turnPoint");
        colliderPosSet = true;
    }
    
}
