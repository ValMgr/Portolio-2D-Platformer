using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

        private Text textDisplayed;

        private void Awake() {
                textDisplayed = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        }

        private List<string> dialogToDisplay;
        public void DisplayDialog(List<string> dialog){

                if(dialog.Count > 0){

                        if(textDisplayed != null){
                                textDisplayed.text = "";
                        }

                        dialogToDisplay = dialog;
                        this.gameObject.SetActive(true);
                }
        }

        private void Update() {
                
                if(dialogToDisplay.Count > 0){

                        textDisplayed.text = dialogToDisplay[0];

                }
                else {
                        this.gameObject.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Space)){
                        dialogToDisplay.RemoveAt(0);
                }

        }
    
}