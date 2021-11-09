using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject food;
    public GameObject obstacle;
    public float spawnFoodRangeX;
    public float spawnObstacleRangeX;

    public GameObject player;
    CollisionController collisionController;
    

    private void Start()
    {
        collisionController = player.GetComponent<CollisionController>();
        InvokeRepeating("SpawnFood", 2f, 2f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(obstacle, transform.position, obstacle.transform.rotation);
        }
    }


    public void SpawnFood()
    {
        if (collisionController.isAlive)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnFoodRangeX, spawnFoodRangeX), transform.position.y, transform.position.z);
            Instantiate(food, spawnPosition, food.transform.rotation);
            Invoke("SpawnObstacle", 1f);
        }
        
    }
    public void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnObstacleRangeX, spawnObstacleRangeX), transform.position.y, transform.position.z);

        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }
}
