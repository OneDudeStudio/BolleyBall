using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, 0, player.position.z) + offset;
    }
}
