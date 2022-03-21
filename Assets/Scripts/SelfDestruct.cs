using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        Destroy(transform.gameObject);
    }
}