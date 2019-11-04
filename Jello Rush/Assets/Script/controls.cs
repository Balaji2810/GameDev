using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controls : MonoBehaviour
{
    private Vector3 touchPosition;
    public Rigidbody rb;
    public GameManager gameManager;
    private Vector3 direction;
    private float moveSpeed = 10f;
    private float x,objx,tx,movepercent;
    private Vector2 startTouchPosition, endTouchPosition;
    private float jumpForce = 70f;
	private bool jumpAllowed = false;
    public Transform player;
    public Swipe swipeControl;
    private int jumps=0,jumpRot=0,jumpcount=1;
    public bool spawner=true;
    public GameObject EndGameObject;
    public GameObject EndGame;
    public float animationTime = 1.0f;
    public iTween.EaseType easetype;
    public iTween.EaseType jumpeasetype;
    public float distance=3.5f,jumpdistance=3.5f;
    
    // Use this for initialization
    private void Start()
    {
       //print(Screen.width);
       spawner=true;
        jumpForce = jumpForce;
        jumpAllowed = jumpAllowed;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (spawner)
        {
            //jump
            if(swipeControl.SwipeUp && jumps>0)
            {
                
                rb.velocity=new Vector3(0,1,0)*130*(moveSpeed*0.016f);
                jumps--;
                jumpRot=1;


               
               
            }

            //jump Rotation

            if(jumpRot==1 && transform.position.y>2)
            {
                transform.Rotate(0,700*Time.deltaTime,0);
                
            }

            if(jumpRot==1 && transform.position.y>8.2f)
            {
                rb.velocity=new Vector3(0,-1,0)*100*(moveSpeed*0.016f);
            }
            
            

           

            
            //move left right
            if(Input.GetKey("d"))
            {
                
                transform.position=new Vector3(transform.position.x+(15f*Time.deltaTime),transform.position.y,transform.position.z);

            }

            if(Input.GetKey("a"))
            {   
                transform.position=new Vector3(transform.position.x-(15f*Time.deltaTime),transform.position.y,transform.position.z);
            }

            


            //endgame

            if(transform.position.y<-50 || transform.position.x>15 || transform.position.x<-15)
            {
                endGame();
            }
        }

    }

    private void FixedUpdate()
    {
        //move left right
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    x = touch.position.x;
                    objx = player.position.x;


                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    tx = touch.position.x - x;
                    movepercent = 20 * (tx / Screen.width);

                   //type2 
                   // transform.position = new Vector3(objx + movepercent, player.position.y, player.position.z);

                    //type 3
                    Vector3 v = new Vector3(objx+movepercent,player.position.y,player.position.z);
                    //iTween.MoveTo(this.gameObject, iTween.Hash("x", objx+movepercent, "time", 0, "easetype", "easeOutSine"));

                    //type 4
                    //rb.MovePosition(new Vector2(objx+movepercent, 0));

                    //type 5
                    transform.position = Vector3.MoveTowards(transform.position, v, 8);

                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    //print("Touch end");
                    //rb.velocity = Vector3.zero;
                    break;
            }


        }
    }
    

    void OnCollisionEnter(Collision colInfo)
    {
        if(colInfo.collider.name=="Base")
        {
            jumps=1;
            jumpRot=0;
            
            if(1==(jumpcount^1))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            jumpcount=jumpcount^1;
        }
        else
        {
            
           
            
             endGame();
            
        }

    }

    void endGame()
    {
        spawner=false;
        gameManager.GameOver();
        GameObject egobj;
        float blastForce=15f;
        float x,y,z;
        Vector3 v;
        Destroy(EndGame);

        //z-1 axis
        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y-(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);

        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y-(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);

        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y+(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);
        
        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y+(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);
        
        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y,transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);

        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y,transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);


        //z+1 axis
        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y-(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);

        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y-(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);

        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y+(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);
        
        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y+(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);
        
        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y,transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);

        x=Random.Range(-0.5f,0.5f);
        y=Random.Range(0.1f,0.5f);
        z=Random.Range(-2f,2f);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y,transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity =new Vector3(x*blastForce,y*blastForce,z*blastForce);
        //print(x+" "+y+" "+z);



        //z-1 axis
        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x - (1f / 2), transform.position.y - (1f), transform.position.z - 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x + (1f / 2), transform.position.y - (1f), transform.position.z - 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x + (1f / 2), transform.position.y + (1f), transform.position.z - 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x - (1f / 2), transform.position.y + (1f), transform.position.z - 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x + (1f / 2), transform.position.y, transform.position.z - 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x - (1f / 2), transform.position.y, transform.position.z - 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);


        //z+1 axis
        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x - (1f / 2), transform.position.y - (1f), transform.position.z + 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x + (1f / 2), transform.position.y - (1f), transform.position.z + 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x + (1f / 2), transform.position.y + (1f), transform.position.z + 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x - (1f / 2), transform.position.y + (1f), transform.position.z + 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x + (1f / 2), transform.position.y, transform.position.z + 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);

        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0.1f, 0.5f);
        z = Random.Range(-2f, 2f);
        v = new Vector3(transform.position.x - (1f / 2), transform.position.y, transform.position.z + 0.5f);
        egobj = Instantiate(EndGameObject, v, Quaternion.identity);
        egobj.GetComponent<Rigidbody>().velocity = new Vector3(x * blastForce, y * blastForce, z * blastForce);
        //print(x+" "+y+" "+z);



    }

    public bool Spawner{get{return spawner;}}
    
}

/* 
if (Input.touchCount > 0)
        {
            Debug.Log("Hello");
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector3(direction.x, 0,0) *50* moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }


private void OnMouseDown()
    {
        Debug.Log("Touch");
    }

   private void OnMouseDrag()
    {
        Debug.Log("Draging");
    }



*/