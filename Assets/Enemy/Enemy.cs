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
    
    private Vector3 checker = new Vector3(1f, 0f, 0f);

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
    
    void FixedUpdate()
    {
        Raymethod();
    }

    private void Raymethod()
    {
        LayerMask layers = LayerMask.GetMask("Topcan","StopMovement");

        Ray ray = new Ray(transform.position, checker);

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, checker,Mathf.Infinity, layers);
        if (hit.Length > 0 && hit[0].collider != null && hit[0].collider.gameObject.CompareTag("Player"))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(checker) * hit[0].distance, Color.yellow);
            foreach (var i in hit)
            {
                Debug.Log(i.collider.gameObject.tag);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(checker) * 10, Color.white);
        }
    }

    private Vector3 GetRandomDir(){
        Vector3[] listVector =  {new Vector3(-1f,0f,0f),new Vector3(0f,1f,0f),new Vector3(1f,0,0f),new Vector3(0f,-1f,0f)};
        int randomIndex = Random.Range(0,listVector.Length);
        checker = listVector[randomIndex];
        return  checker;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "turnpoint") return;
        move = false;
        colliderPosSet = true;
    }
    
}
