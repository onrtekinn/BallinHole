using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask fences,ball;
    int score=0;
    public float speed =7.0f;
    bool right,left,up,down;
    public Text score_txt;
    public GameObject GameOverPanel,RetryPanel;
    bool IsMoving=false;
    //public GameBoard gameBoard;
    
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        //gameBoard=GetComponent<GameBoard>().gameOverPanel.SetActive(true);
        //Score.RetryPanel.SetActive(false);      
        //Score.score_txt.text="SCORE:"+ score;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)&& control(Vector3.right)==false)
        {
            status(true,false,false,false);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)&&control(-Vector3.right)==false)
        {
            status(false,true,false,false);
        }
        else if(Input.GetKey(KeyCode.UpArrow)&&control(Vector3.forward)==false)
        {
            status(false,false,true,false);
        }
        else if(Input.GetKey(KeyCode.DownArrow)&& control(-Vector3.forward)==false)
        {
            status(false,false,false,true);
        }
    }

    private void FixedUpdate() {
        if(IsMoving==true){
            //StartCoroutine(StopMovementCoroutine());
            movement();
        } 
    }
    bool control(Vector3 ray_way){
        RaycastHit IsActive;
        if(Physics.Raycast(transform.position,ray_way,out IsActive,1.0f,fences)){
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
        IsMoving=true;
    }

    void movement(){
        
        if(right)
        {
            //transform.position = transform.position + transform.right * Time.deltaTime * speed;
            rb.velocity=Vector3.right*speed; 
        }
        if(left )
        {
            //transform.position = transform.position -transform.right * Time.deltaTime * speed;
            rb.velocity=-Vector3.right*speed;
        }
        if(up )
        {
            //transform.position = transform.position + transform.forward * Time.deltaTime * speed;
            rb.velocity=Vector3.forward*speed;
        }
        
        if(down)
        {
            //transform.position = transform.position - transform.forward * Time.deltaTime * speed;
            rb.velocity= -Vector3.forward*speed;
        }
        }

    /*IEnumerator StopMovementCoroutine()
    {
        
        yield return new WaitForSeconds(50.0f);
        
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
        Debug.Log("Trigger");
        rb.velocity=Vector3.zero;
        IsMoving=false;
        Destroy (other.gameObject);
        }
        else if (other.gameObject.tag == "ball") {
        Debug.Log("Trigger");
        rb.velocity=Vector3.zero;
        IsMoving=false;
        }
    }
}