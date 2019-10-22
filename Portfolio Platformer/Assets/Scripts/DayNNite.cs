using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNNite : MonoBehaviour
{

    int CurrentHour;
    int CurrentPos; 

    GameObject Cam;
    Vector3 CamPos;
    Color SkyColor;

    void Start(){

        Cam = GameObject.Find("Main Camera");

        CurrentHour = System.DateTime.Now.Hour;
        CurrentPos = CurrentHour * 360 / 24;
        transform.rotation = Quaternion.Euler(Vector3.forward * CurrentPos);

       if(CurrentHour >= 22 && CurrentHour < 24 || CurrentHour >= 0 && CurrentHour < 4){
           SkyColor = new Color(0.08235294f, 0.172549f, 0.2352941f, 0f);
       }
       if(CurrentHour >= 4 && CurrentHour < 10){
           SkyColor = new Color(0.9411765f, 0.7843137f, 0.4705882f, 0f);
       }
       if(CurrentHour >= 10 && CurrentHour < 16){
           SkyColor = new Color(0.254902f, 0.4705882f, 0.8431373f, 0f);
       }
       if(CurrentHour >= 16 && CurrentHour < 21){
           SkyColor = new Color(0.5882353f, 0.371885f, 0.5882353f, 0f);
       }

        Cam.GetComponent<Camera>().backgroundColor = SkyColor;

    }

    private void FixedUpdate() {
        CamPos = Cam.GetComponent<Transform>().position;
        transform.position = new Vector3(CamPos.x, -20f, 5f);
    }
}
