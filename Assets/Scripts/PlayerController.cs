using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Player Movement
    [SerializeField] private float playerSpeed;
    [SerializeField] private float horizontalPlayerSpeed;
    [SerializeField] private Transform pointer;
    public float limitSpeed;
    private CollisionController collisionController;
    public Rigidbody rb;

    //UI
    public Text Speed;
    public int speed;
    

    private void Awake()
    {
        collisionController = gameObject.GetComponent<CollisionController>();
        Time.timeScale = 1;
        rb.GetComponent<Rigidbody>();
        
    }
    
    private void FixedUpdate()
    {
        if (collisionController.isAlive && collisionController.isStarted)
        {
            PlayerControll();
            SpeedCounter();
        }
        if(transform.position.y< -10)
        {
            GameOver();
        }
    }
    public void PlayerControll()
    {
        // движение вперед
        if (rb.velocity.z <= limitSpeed)
        {
            rb.AddForce(Vector3.forward * playerSpeed);
        }
        //управление по горизонтальной оси
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButton(0))
                {
                    pointer.position = hit.point;
                    if(hit.point.x < transform.position.x)
                    {
                    rb.AddForce(Vector3.left * horizontalPlayerSpeed);
                    }
                    else if(hit.point.x > transform.position.x)
                    {
                    rb.AddForce(Vector3.right * horizontalPlayerSpeed);
                    }
                }
            }
        

    }
    void GameOver()
    {
        collisionController.FinishLevel();
    }

    void SpeedCounter()
    {
        speed = (int)Mathf.Round(rb.velocity.z);
        Speed.text = speed.ToString();
    }
    

}
