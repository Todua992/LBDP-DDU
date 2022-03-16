using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float offset;
    public Transform Player;
    public float rotation;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(Player.position.x + x, offset, Player.position.z + y);
        
    }
}
