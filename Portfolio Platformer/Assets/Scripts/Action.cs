using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action : MonoBehaviour {

    [System.NonSerialized]
    public bool canAct = false;

    
    public GameObject PKIcon;
    private Vector3 SpawnPos;


    public void OnTriggerEnter2D(Collider2D other){
        if(!canAct){
            SpawnPos = new Vector3(this.transform.position.x, this.transform.position.y + 2f, this.transform.position.z);
            GameObject PressKeyIcon = Instantiate(PKIcon, SpawnPos, Quaternion.identity) as GameObject;
            PressKeyIcon.name = "PressKeyAction";
            PressKeyIcon.transform.parent = GameObject.Find("GUI").transform;
            canAct = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D other){
        if(canAct){
            GameObject PressKeyIcon = GameObject.Find("PressKeyAction");
            Destroy(PressKeyIcon);
            canAct = false;
        }
    }

}