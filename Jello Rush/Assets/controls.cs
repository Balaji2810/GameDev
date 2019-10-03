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

    // Use this for initialization
    private void Start()
    {
       print(Screen.width);
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    x=touch.position.x;
                    objx=rb.transform.position.x;


                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    tx=touch.position.x-x;
                    movepercent=(tx/Screen.width)*100;
                    //rb.transform.position.x=(movepercent*20)+objx;

                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    print("Touch end");
                    break;
            }


        }

        if(Input.GetKey("d"))
        {
            rb.velocity=new Vector3(1,0,0)*50*moveSpeed*Time.deltaTime;

        }

        if(Input.GetKey("a"))
        {   rb.velocity=new Vector3(-1,0,0)*50*moveSpeed*Time.deltaTime;
            //rb.AddForce(-moveSpeed*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }

        SwipeCheck ();	

    }

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