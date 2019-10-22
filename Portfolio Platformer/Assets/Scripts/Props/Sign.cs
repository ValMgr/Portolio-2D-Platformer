using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sign : MonoBehaviour {

    private bool canAct;
    public GameObject SignPannel;
    public Sprite Project;
    public Sprite About;
    Vector3 SpawnPos;

    [System.NonSerialized]
    public bool isShow = false;
    private bool isRead = false;
    private bool _CloseDelay = false;

    [HideInInspector]
    public int content;

    private void Update() {

        SpawnPos = GameObject.Find("Main Camera").GetComponent<Transform>().position;
        SpawnPos.z = SpawnPos.z + 10f;

        canAct = this.GetComponent<Action>().canAct;

        if(Input.GetAxis("Action") > 0){
            if(canAct){
                if(!isShow && !_CloseDelay){
                    GameObject Sign = Instantiate(SignPannel, SpawnPos, Quaternion.identity) as GameObject;
                    Sign.name = "SignUI";
                    Sign.transform.parent = GameObject.Find("GUI").transform;
                    

                    switch (content){
                        case 0:
                            Sign.GetComponent<SpriteRenderer>().sprite = Project;
                            break;
                        case 1:
                            Sign.GetComponent<SpriteRenderer>().sprite = About;
                            break;
                        default:
                            break;
                    }

                    isShow = true;
                    StartCoroutine("ReadingTime");
                   

                }
            }
        }

        if(Input.GetAxis("Action") > 0){
            if(isShow && isRead){
                Destroy(GameObject.Find("SignUI"));
                isShow = false;
                isRead = false;
                _CloseDelay = true;
                StartCoroutine("CloseDelay");
            }
        }
    }

    

    IEnumerator ReadingTime(){
        yield return new WaitForSeconds(0.5f);
        isRead = true;
    }

    IEnumerator CloseDelay(){
        yield return new WaitForSeconds(0.5f);
        _CloseDelay = false;
    }
    
}