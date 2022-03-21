using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float timer;
    private void OnCollisionEnter(Collision collision) {
        Destroy(transform.gameObject);
    }

    public void Update() {
        if (timer > 0f) {
            timer -= Time.deltaTime;
            if (timer <= 0f) {
                Destroy(gameObject);
            }
        }
    }

}