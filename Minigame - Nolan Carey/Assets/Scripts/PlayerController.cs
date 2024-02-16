using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public GameObject unit1;
    public GameObject unit2;
    public float xBound = 8.0f;
    public float yBound = 4.5f;

    // Update is called once per frame
    void Update()
    {
        //movement, no anims
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // focus controls

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 1.5f;
            unit1.transform.Rotate((float)0, 0, (float)45);
            unit2.transform.Rotate((float)0, 0, (float)-45);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
            unit1.transform.Rotate((float)0, 0, (float)-45);
            unit2.transform.Rotate((float)0, 0, (float)45);
        }
        
        //cursed relic, do not touch or else the spirits may be angry

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x,-xBound,xBound),
            Mathf.Clamp(transform.position.y,(float)-4.5,(float)4.5)
            );
        
        
    }

    private void FixedUpdate()
    {
        //also used for movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
