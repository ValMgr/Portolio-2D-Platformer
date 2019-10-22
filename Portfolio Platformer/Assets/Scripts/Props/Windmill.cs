using UnityEngine;

public class Windmill : MonoBehaviour {
    public GameObject Wheel;
    private void Update() {

        Wheel.transform.Rotate(Vector3.forward);
    }
}