using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {
    
    
    public Rigidbody2D rb2d;
    public Animator animator;
    public float speed = 10f;
    public float jumpForce = 5f;


    private bool isJumping = false;
    private bool isDoubleJumping = false;

    [System.NonSerialized]
    public bool canMove = true;
    private GameObject menu;
    private bool menuDisplayed = false;

    private GameObject PKIcon;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);

        menu = GameObject.Find("Menu");
        menu.SetActive(false);
        PKIcon = Resources.Load<GameObject>("Prefabs/PressKeyAction");
    }

    private Vector3 doorPosition;

    public void SetDoorPosition(Vector3 newPos){
        doorPosition = newPos;
    }
    void OnLevelWasLoaded(){
        this.transform.position = doorPosition;
    }

    private void Update() {

        if(Input.GetKeyDown("escape")){
            getMenu();
        }

        Action();
    }

    private void FixedUpdate() {
        Moove();
        Jump();
        DoubleJump();

        if(JumpDelay > 0){
            JumpDelay = JumpDelay - Time.deltaTime;
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

    float JumpDelay = 0f;
    void Jump(){

        if(Input.GetAxis("Vertical") > 0 && !isJumping && canMove && !menuDisplayed){
            rb2d.AddForce(new Vector2 (rb2d.velocity.x, jumpForce * 120f));
            isJumping = true;
            JumpDelay = 0.5f;
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

        if(other.gameObject.CompareTag("Start")){
            SceneManager.LoadScene("Main");
            GameObject.Find("Main Camera").gameObject.transform.GetChild(1).gameObject.SetActive(true);
            doorPosition = new Vector3(0, 0, 0);
        }

    }

    private GameObject area;
    private void OnTriggerEnter2D(Collider2D other) {

        if(GameObject.Find("PressKeyDisplay") == null){
            Vector3 SpawnPos = new Vector3(other.transform.position.x, other.transform.position.y + 2f, other.transform.position.z);
            GameObject PressKeyIcon = Instantiate(PKIcon, SpawnPos, Quaternion.identity) as GameObject;
            PressKeyIcon.name = "PressKeyDisplay";
            //PressKeyIcon.transform.parent = GameObject.Find("GUI").transform;
        }
        

        area = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        GameObject PressKeyIcon = GameObject.Find("PressKeyDisplay");
        Destroy(PressKeyIcon);
        area = null;
    }

    private void Action(){

        if(Input.GetKeyDown("e")){
            if(area != null){
                if(area.CompareTag("Signs")){
                    area.GetComponent<Sign>().Display();
                }
                if(area.CompareTag("Door")){
                    area.GetComponent<Door>().OpenDoor();
                }
                if(area.CompareTag("NPC")){
                    area.GetComponent<NPC>().GetDialog();
                }
            }
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