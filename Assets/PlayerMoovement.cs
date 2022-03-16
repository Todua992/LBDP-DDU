using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public Rigidbody rb;
    public Camera cam;
    Vector3 movement;
    Vector3 mousePosi;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
       movement.z = Input.GetAxis("Vertical");

        mousePosi = Input.mousePosition;

        mousePosi.x -= Screen.width / 2;
        mousePosi.y -= Screen.width / 2;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePosi - rb.position;
        float angle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg + 90f;
        rb.rotation = Quaternion.Euler(0, angle, 0);
    }
}
