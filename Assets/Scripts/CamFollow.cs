using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamFollow : MonoBehaviour
{
    public Transform player;
    private CollisionController collisionController;
    public Vector3 offset;
    public float delay;
    
    private void Start()
    {
        collisionController = GameObject.FindGameObjectWithTag("Player").GetComponent<CollisionController>();
        
    }
    private void LateUpdate()
    {
        if (collisionController.isAlive)
        {
            FollowPlayer();
        } 
    }

    void FollowPlayer()
    {
        if (collisionController.isAlive & collisionController.isfinished == false)
        {
            transform.position = new Vector3(player.position.x, 0, player.position.z) + offset;
        }
        else transform.position = transform.position; 
        
    }
}
