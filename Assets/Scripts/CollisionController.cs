using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CollisionController : MonoBehaviour
{
    //
    float smoothSpeed = 2f;
    //References
    private PlayerController playerController;
    public GameObject player;
    //Bool
    public bool isfinished = false;
    public bool isAlive = true;
    public bool isStarted = false;
    public bool hasFever = false;
    //UI
    public Text points;
    public int point;
    public Text health;
    public int healthCounter = 0;
    public GameObject startPanel;
    public Button play;
    public Button restart;


    private void Awake()
    {
        startPanel.SetActive(true);
        restart.gameObject.SetActive(false);
    }
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    private void Update()
    {
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collision with basic food
        if (other.gameObject.CompareTag("Food"))
        {
            point += 5;
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);

            switch (point)
            {
                case 10:
                    IncreasePlayerSpeed(1.5f);
                    break;
                case 25:
                    IncreasePlayerSpeed(2f);
                    break;
                case 50:
                    IncreasePlayerSpeed(3f);
                    break;
                case 100:
                    IncreasePlayerSpeed(4f);
                    break;
                default:
                    break;
            }
            
        }
       else if (other.gameObject.CompareTag("Obstacle"))
        {
            if (healthCounter > 1)
            {
                healthCounter--;
            }
            else if(healthCounter == 1)
            {
                healthCounter--;
                isAlive = false;
                isStarted = false;
                Invoke("FinishLevel", 1.5f);

            }
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            startPanel.SetActive(true);
            FinishLevel();
        }
        
    }
    void IncreasePlayerSpeed(float increase)
    {
        playerController.limitSpeed = Mathf.Lerp(playerController.limitSpeed, playerController.limitSpeed * increase, smoothSpeed);
    }

    void UpdateText()
    {
        points.text = point.ToString();
        health.text = "X" + healthCounter.ToString();
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        isStarted = true;
        isAlive = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
        StartGame();
    }
    public void FinishLevel()
    {
        play.gameObject.SetActive(false);
        Time.timeScale = 0;
        isfinished = true;
        startPanel.SetActive(true);
        restart.gameObject.SetActive(true);
        Debug.Log(isfinished);
    }



}
