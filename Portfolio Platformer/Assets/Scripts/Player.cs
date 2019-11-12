using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    
    
    public Rigidbody2D rb2d;
    public Animator animator;
    public float speed = 10f;
    public float jumpForce = 5f;


    private bool isJumping = false;
    private bool isDoubleJumping = false;

    private GameObject mant;
    private GameObject body;
    private GameObject leg0;
    private GameObject leg1;

    private bool canMove = true;
    public GameObject menu;
    private bool menuDisplayed = false;

    private void Start() {

        mant = GameObject.Find("Mant");
        body = GameObject.Find("Body");
        leg0 = GameObject.Find("Leg (0)");
        leg1 = GameObject.Find("Leg (1)");

    }

    private void Update() {
        var Signs = GameObject.FindGameObjectsWithTag("Signs");
        foreach (var Sign in Signs){
            canMove = !Sign.GetComponent<Sign>().isShow;
                if(!canMove){
                    break;
                }
        }
    }

    private void FixedUpdate() {

        
       
        if(Input.GetKeyDown("escape")){
            getMenu();
        }

        Moove();
        Jump();
        DoubleJump();
        JumpDelay = JumpDelay - Time.deltaTime;
    }

    float JumpDelay = 0f;
    void Jump(){

        if(Input.GetAxis("Vertical") > 0 && !isJumping && canMove && !menuDisplayed){
            rb2d.AddForce(new Vector2 (rb2d.velocity.x, jumpForce * 120f));
            isJumping = true;
            JumpDelay = 0.5f;
        }
       
    }

    void Moove(){

        if(canMove && !menuDisplayed){
            float moove = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(speed * moove, rb2d.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(moove));
        }
        
        if(Input.GetAxis("Horizontal") < 0f){
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if(Input.GetAxis("Horizontal") > 0f){
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void DoubleJump(){
         if(Input.GetAxis("Vertical") > 0 && isJumping && !isDoubleJumping && (JumpDelay < 0.1f && JumpDelay > -0.1f)){
            rb2d.AddForce(new Vector2 (rb2d.velocity.x, jumpForce * 85f));
            isDoubleJumping = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isJumping = false;
            isDoubleJumping = false;
            rb2d.velocity = Vector2.zero;
        }

        if(other.gameObject.CompareTag("ResetHeight")){
            this.transform.position = new Vector3(this.transform.position.x, 15f, this.transform.position.z);
        }

    }

    private void getMenu(){

        if(!menu.activeSelf){
            menu.SetActive(true);
            menuDisplayed = true;
        }
        else{
            menu.SetActive(false);
            menuDisplayed = false;
        }
    }

    public void Exit(){
        Application.OpenURL("./home.html");
        //Application.OpenURL("http://valentin-magry.fr/home.html");
    }

    

}