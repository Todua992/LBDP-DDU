using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate() {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
    }
}