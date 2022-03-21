using System.Collections;
using UnityEngine;

namespace PatrogueStudio.Astar {
    public class Unit : MonoBehaviour {
        public Transform target;
        public float speed;
        private Vector3[] path;
        private int targetIndex;
        private float timer = 0.1f;
        public float timerUPS;
        public Rigidbody rb;
        private Vector3 oldTarget;
        public float rotationspeed = 20;

        private void Start() {
            PathRequestManager.RequestPath(transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)), target.position, OnPathFound);
            oldTarget = target.position;

            timer = 1 / timerUPS;
        }

        [System.Obsolete]
        private void Update() {
            if (timer <= 0f) {
                if (oldTarget != target.position) {
                    PathRequestManager.RequestPath(transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)), target.position, OnPathFound);
                }

                oldTarget = target.position;
                timer = 1 / timerUPS;
            } else {
                timer -= Time.deltaTime;
            }
        }

        public void OnPathFound(Vector3[] newPath, bool pathSuccessfull) {
            if (pathSuccessfull) {
                targetIndex = 0;
                path = new Vector3[0];
                path = newPath;
                StopCoroutine(nameof(FollowPath));
                StartCoroutine(nameof(FollowPath));
            }
        }

        private IEnumerator FollowPath() {
            Vector3 currentWaypoint = path[0];

            while (true) {
                if (transform.position == currentWaypoint) {
                    targetIndex++;
                    if (targetIndex >= path.Length) {
                        targetIndex = 0;
                        path = new Vector3[0];
                        yield break;
                    }

                    currentWaypoint = path[targetIndex];
                }

                Vector3 direction = currentWaypoint - transform.position;
                direction.y = 0f;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.SetPositionAndRotation(Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime), Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime));

                yield return null;
            }
        }

        public void OnDrawGizmos() {
            if (path != null) {
                for (int i = targetIndex; i < path.Length; i++) {
                    Gizmos.color = Color.black;
                    Gizmos.DrawSphere(path[i], 0.2f);

                    if (i == targetIndex) {
                        Gizmos.DrawLine(transform.position, path[i]);
                    } else {
                        Gizmos.DrawLine(path[i - 1], path[i]);
                    }
                }
            }
        }
    }
}
