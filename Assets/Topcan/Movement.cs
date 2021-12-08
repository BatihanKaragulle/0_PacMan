using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 10;
    public GameObject myfood;
    public int can = 4;

    int KalpSayisi;

    public GameObject KalpTutucagi;
    public int getcanvalue()
    {
        return can;
    }
    // Start is called before the first frame update
   void Start()
    {
        Debug.Log(can);
    }
   // Update is called once per frame
   public void Update()
    {
        KalpSayisi = KalpTutucagi.GetComponent<Health>().getHealthPoints();
        if(myfood!=null){
            bool isActive  = myfood.GetComponent<Food>().getActive();
        }
        if(KalpSayisi <= 0){
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
    void FixedUpdate() 
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float xmovement = inputX * speed;
        float ymovement = inputY * speed;

        Vector2 movement= new Vector2(xmovement, ymovement);

        movement *= Time.deltaTime;

         transform.Translate(movement); 
    }

    public void CanInc()
    {
        can++;
        Debug.Log(can);
    }
    public void CanDec()
    {
        can--;
        Debug.Log(can);
    }
}
