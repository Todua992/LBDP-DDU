using UnityEngine;

public class Shooting : MonoBehaviour {
    [SerializeField] private Transform start;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private AudioSource _audiosource;




    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            _audiosource.Play();
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(this.bullet, start.position, start.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(start.right * bulletSpeed, ForceMode.Impulse);
    }
}