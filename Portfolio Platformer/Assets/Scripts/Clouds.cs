using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Clouds : MonoBehaviour {
    
    public float Speed = 0;
    Vector3 that;

    private void Start() {
        that = this.transform.position;
    }

    private Component[] childrens;
    bool isReset = false;

    private void Update() {
        
        that = new Vector3(that.x + 1 * Speed / 500, that.y, that.z);
        this.transform.position = that;

        
        var childrens = GetComponentsInChildren<SpriteRenderer>();
        
            foreach (SpriteRenderer cloud in childrens){

                if(that.x > 40f){
                    StartCoroutine("FadeOutOpacity", cloud);
                }

                if(isReset){
                    StopCoroutine("FadeOutOpacity");
                    StartCoroutine("FadeInOpacity", cloud);
                }
            }
    }


    IEnumerator FadeOutOpacity(SpriteRenderer cloud){


            for (float o = 1.000f; o >= 0f; o -= 0.01f){
                cloud.material.color = new Vector4(1.000f, 1.000f, 1.000f, o);
                yield return null;  
            }

            this.transform.position = new Vector3(0f, 0f, 3f);
            that = this.transform.position;
            isReset = true;        
    }

    IEnumerator FadeInOpacity(SpriteRenderer cloud){

        for (float o = 0.000f; o <= 1f; o += 0.01f){
                cloud.material.color = new Vector4(1.000f, 1.000f, 1.000f, o);
                yield return null;  
        }

        isReset = false;
        
    }
}