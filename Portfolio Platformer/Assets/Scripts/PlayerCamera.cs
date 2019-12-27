using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    
    public GameObject target;
    private float yPos;

    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update() {

        yPos = target.transform.position.y;

        if(yPos < 8f && yPos > -1f){
            this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        }
        else if(yPos < -1f){
            this.transform.position = new Vector3(target.transform.position.x, -1f, this.transform.position.z);

        }
        else if(yPos > 8f){
            this.transform.position = new Vector3(target.transform.position.x, 8f, this.transform.position.z);

        }
    }

}