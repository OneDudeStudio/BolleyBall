using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    GameObject player;
    int offset = 10;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(transform.position.z < player.transform.position.z - offset)
        {
            Destroy(gameObject);
        }
    }
}