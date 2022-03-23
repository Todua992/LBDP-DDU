using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float timer;
    [SerializeField] public bool onCollisionDestroy = true;
    private void OnCollisionEnter(Collision collision) {
        if(onCollisionDestroy == true) { 
        Destroy(gameObject);
    }
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