using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Door : MonoBehaviour {
    
    public string nextScene;

    public void OpenDoor(){
        SceneManager.LoadScene(nextScene);
    }

}