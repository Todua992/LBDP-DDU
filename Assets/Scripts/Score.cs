using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] private Text text;
    public int score = 0;

    void Update()
    {
        text.text = (score * 100).ToString();
    }
}
