using UnityEngine;

public class Billboard : MonoBehaviour {
    private Transform cam;

    private void Start() {
        cam = GameObject.Find("MainCamera").GetComponent<Transform>();
    }

    private void LateUpdate() {
        transform.LookAt(transform.position + cam.forward);
    }
}