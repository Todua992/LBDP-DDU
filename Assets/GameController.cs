using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 innerZone;
    [SerializeField] private Vector2 outerZone;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        float x;
        float y;

        do {
            x = Random.Range(0, outerZone.x);
            y = Random.Range(0, outerZone.y);
        } while (x < innerZone.x && y < innerZone.y);

        x *= Random.Range(0, 2) * 2 - 1;
        y *= Random.Range(0, 2) * 2 - 1;

        Instantiate(enemy, new Vector3(x + player.position.x, 0f, y + player.position.z), transform.rotation);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(player.position, new Vector3(innerZone.x * 2, 1, innerZone.y * 2));

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(player.position, new Vector3(outerZone.x * 2, 1, outerZone.y * 2));
    }
}