using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private Vector3 offset;

    void FixedUpdate() {
        transform.position = new Vector3(Player.position.x + offset.x, offset.y, Player.position.z + offset.z);
    }
}