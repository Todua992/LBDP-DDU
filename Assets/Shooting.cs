using UnityEngine;

public class Shooting : MonoBehaviour {
    public Transform Startpoint;
    public GameObject BulletPrefab;

    public float bulletSpeed = 20f;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(BulletPrefab, Startpoint.position, Startpoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(Startpoint.right * bulletSpeed, ForceMode.Impulse);
    }
}