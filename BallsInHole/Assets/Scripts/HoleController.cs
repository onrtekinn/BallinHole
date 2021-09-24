using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
 public Rigidbody rb;
    public LayerMask ball;
    public float speed =5.0f;
    bool right,left,up,down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)&& control(Vector3.right)==false)
        {
            status(true,false,false,false);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)&& control(-Vector3.right)==false)
        {
            status(false,true,false,false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)&& control(Vector3.forward)==false)
        {
            status(false,false,true,false);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)&& control(-Vector3.forward)==false)
        {
            status(false,false,false,true);
        }
    }
    
    private void FixedUpdate() {
        movement();
    }
    bool control(Vector3 ray_way){
        RaycastHit IsActive;

        if(Physics.Raycast(transform.position,ray_way,out IsActive,2.0f,ball)){
            return true;
        }
        else
        {
            return false;
        }
    }
    void status(bool go_right,bool go_left,bool go_up,bool go_down){
        right=go_right;
        left=go_left;
        up=go_up;
        down=go_down;
    }

    void movement(){
        if(right)
        {
            //rb.velocity=Vector3.right*speed;
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
         if(left)
        {
            rb.MovePosition(transform.position -transform.right * Time.deltaTime * speed);
            //rb.velocity=-Vector3.right*speed;
        }
         if(up)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            //rb.velocity=Vector3.forward*speed;

        }
         if(down)
        {
            rb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
            //rb.velocity= -Vector3.forward*speed;
        }
    }
    void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "ball") {
    Destroy (this.gameObject);
    }
    }
}