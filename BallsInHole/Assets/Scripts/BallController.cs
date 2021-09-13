using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask fences;
    //private GameObject[] icecubes;
    //private GameObject[]coins;
    int score=0;
    public float speed =5.0f;
    bool right,left,up,down;
    private bool HaveSpeed;
    public Text score_txt;
    public GameObject GameOverPanel;
    public GameObject RetryPanel;
    //Vector3 move;
    //Vector3 icecubePos,ballPos;

    // Start is called before the first frame update
    void Start()
    {
        //coins =GameObject.FindGameObjectsWithTag("coins");
        //icecubes=GameObject.FindGameObjectsWithTag("icecube");
        rb=GetComponent<Rigidbody>();
        GameOverPanel.SetActive(false);
        RetryPanel.SetActive(false);        
        HaveSpeed=true;
        score_txt.text="SCORE:"+ score;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.RightArrow)&& control(Vector3.right)==false)
        {
            status(true,false,false,false);
        }
         else if(Input.GetKeyDown(KeyCode.LeftArrow)&& control(-Vector3.right)==false)
        {
            status(false,true,false,false);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow)&& control(Vector3.forward)==false)
        {
            status(false,false,true,false);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)&& control(-Vector3.forward)==false)
        {
            status(false,false,false,true);
        }
    }
    
    private void FixedUpdate() {
        movement();
        SetSpeed();
    }

    bool control(Vector3 ray_way){
        RaycastHit IsActive;

        if(Physics.Raycast(transform.position,ray_way,out IsActive,2.0f,fences)){
            return true;
        }
        else
        {
            return false;
        }
    }

    void SetSpeed(){
        if(speed==0.0f){
            HaveSpeed =false;
            //rb.velocity=Vector3.zero*speed;
            //control=true;
        }
        else{
            HaveSpeed =true;
        }
    }
    void status(bool go_right,bool go_left,bool go_up,bool go_down){
        right=go_right;
        left=go_left;
        up=go_up;
        down=go_down;
    }

    void movement(){
        if(right && HaveSpeed)
        {
            speed=5.0f;
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
            //rb.velocity=Vector3.right*speed; 
        }
         if(left && HaveSpeed)
        {
            speed=5.0f;
            rb.MovePosition(transform.position -transform.right * Time.deltaTime * speed);
            //rb.velocity=-Vector3.right*speed;

        }
         if(up && HaveSpeed)
        {
            speed=5.0f;
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            //rb.velocity=Vector3.forward*speed;
        }
         if(down && HaveSpeed)
        {
            speed=5.0f;
            rb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
            //rb.velocity= -Vector3.forward*speed;
        }   
    }
       /* void FindIceCubes(){
        icecubes=GameObject.FindGameObjectsWithTag("icecube");
        icecubePos =icecubes[0].transform.position;
        ballPos =gameObject.transform.position;
        if (icecubes.Length > 0){
        print(icecubes[0].transform.position);}
    }*/
    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "coins") {
        Destroy (coll.gameObject);  
        score+=10;
        score_txt.text="score"+ score;
        }   
    }
    void OnCollisionStay(Collision other) {
    if (other.gameObject.tag == "hole") {
    Destroy (gameObject);
    GameOverPanel.SetActive(true);
    }
    else if (other.gameObject.tag == "traps") {
    Destroy (gameObject);
    RetryPanel.SetActive(true);
    }
    else if (other.gameObject.tag == "icecube") {
    //FindIceCubes();
    Destroy (other.gameObject);
    speed=0.0f;
    //ballPos=icecubePos;
    }
   }
}