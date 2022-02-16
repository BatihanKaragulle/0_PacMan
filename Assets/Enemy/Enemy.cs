using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public LayerMask whatStopsMovement;
    private Vector3 directionTry;
    private Vector3 newMovePoint;
    private bool move;
    private bool colliderPosSet;

    private bool chase;
    private Vector3 PlayerPos;
    
    private Vector3 laserDirection = new Vector3(1f, 0f, 0f);

    public Movement Player; 

    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        directionTry = new Vector3 (1f,0f,0f);
        newMovePoint = transform.position;
        move = true;
        Random.InitState(System.DateTime.Now.Millisecond);
        chase = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (!chase)
        {
            if (move)
            {
                transform.position = Vector3.MoveTowards(transform.position, newMovePoint, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, newMovePoint) == 0f)
                {
                    if (!Physics2D.OverlapCircle(newMovePoint + directionTry, .1f, whatStopsMovement))
                        newMovePoint += directionTry;
                }
            }
            else if (colliderPosSet && Vector3.Distance(transform.position, newMovePoint) == 0f)
            {
                directionTry = GetRandomDir();
                while (Physics2D.OverlapCircle(transform.position + directionTry, .001f, whatStopsMovement))
                {
                    directionTry = GetRandomDir();
                }

                colliderPosSet = false;
                move = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, newMovePoint, speed * Time.deltaTime);
            }
        }
        else //chasing true
        {
            Vector3 playerPos = transform.position + laserDirection;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (!Player.immune)
            PlayerDetection();
        else
            chase = false;
    }

    private void PlayerDetection()
    {
        LayerMask importantLayers = LayerMask.GetMask("Topcan", "StopMovement");

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, laserDirection, Mathf.Infinity, importantLayers);
        if (hit.Length > 0 && hit[0].collider != null && hit[0].collider.gameObject.CompareTag("Player"))
        {
            Debug.DrawRay(transform.position, laserDirection * hit[0].distance, Color.yellow);
            chase = true;
            PlayerPos = hit[0].transform.position;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(laserDirection) * 10, Color.white);
            chase = false;
        }
    }


    private Vector3 GetRandomDir(){
        Vector3[] listVector =  {new Vector3(-1f,0f,0f),new Vector3(0f,1f,0f),new Vector3(1f,0,0f),new Vector3(0f,-1f,0f)};
        int randomIndex = Random.Range(0,listVector.Length);
        laserDirection = listVector[randomIndex];
        return  listVector[randomIndex];
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "turnpoint") return;
        move = false;
        colliderPosSet = true;
    }
    
}
