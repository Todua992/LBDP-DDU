using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform start1;
    [SerializeField] private Transform start2;
    [SerializeField] private Transform start3;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private AudioSource _audiosource;
 

    private void Start()
    {
        InvokeRepeating("Shoot", 1, 2.0f);
        InvokeRepeating("Shoot1", 1, 2.0f);
        InvokeRepeating("Shoot2", 1, 2.0f);
        InvokeRepeating("Shoot3", 1, 2.0f);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(this.bullet, start.position, start.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(start.transform.TransformDirection(Vector3.up) * bulletSpeed, ForceMode.Impulse);
    }

    private void Shoot1()
    {
        GameObject bullet = Instantiate(this.bullet, start1.position, start1.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(start1.transform.TransformDirection(Vector3.up) * bulletSpeed, ForceMode.Impulse);
    }

    private void Shoot2()
    {
        GameObject bullet = Instantiate(this.bullet, start2.position, start2.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(start2.transform.TransformDirection(Vector3.up) * bulletSpeed, ForceMode.Impulse);
    }

    private void Shoot3()
    {
        GameObject bullet = Instantiate(this.bullet, start3.position, start3.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(start3.transform.TransformDirection(Vector3.up) * bulletSpeed, ForceMode.Impulse);
    }
}