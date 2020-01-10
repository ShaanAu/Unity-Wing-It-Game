using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControls : MonoBehaviour
{
    public static GameControls Instance;

    public float scrollSpeed = -0.4f;
    public bool isGameOver = false;
    private int score = 0;

    public Text scoreText;
    public GameObject GameOverText;

  

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
       
    }




    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void Score()
    {
        if (isGameOver) { return; }

        score++;
        scoreText.text = "Score: " + score;

    }



    public void Death()
    {
        isGameOver = true;
        GameOverText.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Orb"))
        {
            other.gameObject.SetActive(false);
            score--;
        }
    }



}
