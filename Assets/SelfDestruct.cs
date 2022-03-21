using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        Destroy(transform.gameObject);
    }
}