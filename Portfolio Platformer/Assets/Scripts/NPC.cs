using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public List<string> dialog;
    private GameObject dialogManager;

    private void Awake() {
        dialogManager = GameObject.Find("DialogManager");
        dialogManager.SetActive(false);
    }
    public void GetDialog(){
        //dialogManager.SetActive(true);
        dialogManager.GetComponent<DialogManager>().DisplayDialog(dialog);

    }
}
