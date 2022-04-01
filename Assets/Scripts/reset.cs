using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Main");
        }
    }
}
