using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sign : MonoBehaviour {

    public GameObject SignPannel;
    Vector3 SpawnPos;

    [System.NonSerialized]
    public bool isShow = false;
    public Sprite content;


    public void Display(){
        if(!isShow){
                    SpawnPos = GameObject.Find("Main Camera").GetComponent<Transform>().position;
                    SpawnPos.z = SpawnPos.z + 10f;
                    GameObject Sign = Instantiate(SignPannel, SpawnPos, Quaternion.identity) as GameObject;
                    Sign.name = "SignUI";
                    Sign.transform.parent = GameObject.Find("GUI").transform;
                    Sign.GetComponent<SpriteRenderer>().sprite = content;
                    isShow = true;
                    GameObject.Find("Player").GetComponent<Player>().canMove = false;
        }
        else if(isShow){
            Destroy(GameObject.Find("SignUI"));
            isShow = false;
            GameObject.Find("Player").GetComponent<Player>().canMove = true;
        }
    }

    
    
}