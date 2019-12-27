using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;


public class Door : MonoBehaviour {
    
    public string nextScene;
    public Vector2 spawnPos;


    public void OpenDoor(){
        SceneManager.LoadScene(nextScene);
        Vector3 spawnPosV3 = spawnPos;
        GameObject.Find("Player").GetComponent<Player>().SetDoorPosition(spawnPosV3);
    }

}