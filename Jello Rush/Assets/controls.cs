using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controls : MonoBehaviour
{
    private Vector3 touchPosition;
    public Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    private float x,objx,tx,movepercent;
    private Vector2 startTouchPosition, endTouchPosition;
    private float jumpForce = 7000f;
	private bool jumpAllowed = false;
    public Transform player;
    public Swipe swipeControl;
    private int jumps=0,jumpRot=0,jumpcount=1;
    public bool spawner=true;
    public GameObject EndGameObject;
    public GameObject EndGame;
    
    // Use this for initialization
    private void Start()
    {
       //print(Screen.width);
       spawner=true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(spawner)
        {
            //jump
            if(swipeControl.SwipeUp && jumps>0)
            {
                
                rb.velocity=new Vector3(0,1,0)*120*(moveSpeed*0.016f);//Time.deltaTime;
                //rb.AddForce(0,50*moveSpeed*Time.deltaTime,0,ForceMode.VelocityChange);
                jumps--;
                jumpRot=1;
                //print("movespeed:"+moveSpeed+" Time.deltaTime:"+Time.deltaTime);

            }

            //jump Rotation

            if(jumpRot==1 && transform.position.y>2)
            {
                transform.Rotate(0,20,0);
                print(transform.position.y);
                
                //transform.position=new Vector3(transform.position.x,transform.position.y-0.03f,transform.position.z);
            }

            if(jumpRot==1 && transform.position.y>7.9f)
            {
                rb.velocity=new Vector3(0,-1,0)*100*(moveSpeed*0.016f);
            }
            
            //move left right
            if(Input.touchCount>0)
            {
                Touch touch = Input.GetTouch(0);

                // Handle finger movements based on touch phase.
                switch (touch.phase)
                {
                    // Record initial touch position.
                    case TouchPhase.Began:
                        x=touch.position.x;
                        objx=player.position.x;


                        break;

                    // Determine direction by comparing the current touch position with the initial one.
                    case TouchPhase.Moved:
                        tx=touch.position.x-x;
                        movepercent=30*(tx/Screen.width);
                        //rb.transform.position.x=(movepercent*20)+objx;
                        transform.position= new Vector3(objx+movepercent,player.position.y,player.position.z);

                        break;

                    // Report that a direction has been chosen when the finger is lifted.
                    case TouchPhase.Ended:
                        print("Touch end");
                        break;
                }


            }

            //move left right
            if(Input.GetKey("d"))
            {
                //rb.velocity=new Vector3(1,0,0)*80*moveSpeed*Time.deltaTime;
                transform.position=new Vector3(transform.position.x+(15f*Time.deltaTime),transform.position.y,transform.position.z);

            }

            if(Input.GetKey("a"))
            {   //rb.velocity=new Vector3(-1,0,0)*80*moveSpeed*Time.deltaTime;
                //rb.AddForce(-moveSpeed*Time.deltaTime,0,0,ForceMode.VelocityChange);
                transform.position=new Vector3(transform.position.x-(15f*Time.deltaTime),transform.position.y,transform.position.z);
            }

            // SwipeCheck ();	


            //endgame

            if(transform.position.y<-50 || transform.position.x>15 || transform.position.x<-15)
            {
                endGame();
            }
        }

    }
    /*
    private void FixedUpdate()
	{
		JumpIfAllowed ();
	}

	private void SwipeCheck()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
			startTouchPosition = Input.GetTouch (0).position;

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
			endTouchPosition = Input.GetTouch (0).position;
			if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
				jumpAllowed = true;
		}
	}

	private void JumpIfAllowed()
	{
		if (jumpAllowed) {
			rb.AddForce (Vector2.up * jumpForce*Time.deltaTime*3);
			jumpAllowed = false;
		}
	}
    */
        
    void OnCollisionEnter(Collision colInfo)
    {
        if(colInfo.collider.name=="Base")
        {
            jumps=1;
            jumpRot=0;
            //transform.Rotate(0,90,0);
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
        Destroy(EndGame);
        GameObject egobj;
        float blastForce=850f;
        float x,y,z;
        Vector3 v;

        //z-1 axis
        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y-(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);

        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y-(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);

        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y+(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);
        
        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y+(1f),transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);
        
        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y,transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);

        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y,transform.position.z-0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);


        //z+1 axis
        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y-(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);

        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y-(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);

        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y+(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);
        
        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y+(1f),transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);
        
        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x+(1f/2),transform.position.y,transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);

        x=Random.Range(-2,2);
        y=Random.Range(-2,2);
        z=Random.Range(-2,2);
        v= new Vector3(transform.position.x-(1f/2),transform.position.y,transform.position.z+0.5f);
        egobj=Instantiate(EndGameObject,v,Quaternion.identity);
        egobj.GetComponent<Rigidbody>().AddRelativeForce(x*blastForce,y*blastForce,z*blastForce);

        

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