using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 mousePos;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg + 90f;
        rb.rotation = Quaternion.Euler(0, angle, 0);
    }
}