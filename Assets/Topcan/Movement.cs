using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //movement icin declare edilen
    float speed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

    //cani icin declare edilen attributlar
    public GameObject myfood;
    public int can = 4;
    int max_can = 4;
    int KalpSpriteSayisi;
    public GameObject KalpTutucagi;
    public int getcanvalue()
    {
        return can;
    }
    // Start is called before the first frame update
   void Start()
    {
        movePoint.parent = null;
    }
    // Update is called once per frame
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position)== 0f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal"))==1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f), .1f, whatStopsMovement))
                    movePoint.position = movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f);              
            }


            if(Mathf.Abs(Input.GetAxisRaw("Vertical"))==1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"),0f), .1f, whatStopsMovement))
                    movePoint.position = movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"),0f);
            }
        }



        KalpSpriteSayisi = KalpTutucagi.GetComponent<Health>().getHealthPoints();//Healthden kalp sayısını alıyo. 
        if(myfood!=null){
            bool isActive  = myfood.GetComponent<Food>().getActive();
        }
        if(can > max_can){
            can = max_can;
        }
        if(KalpSpriteSayisi <= 0){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("food") && myfood != null){
            bool isActive  = myfood.GetComponent<Food>().getActive();
            if(isActive)
                CanInc();
        }
        else if(other.CompareTag("enemy")){
            CanDec();
        }
    }

    public void CanInc()
    {
        can++;
    }
    public void CanDec()
    {
        can--;
    }
}
