﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{

    public static GameControll instance;

    private int score = 0;

    public Text scoreText;
    public float scrollSpeed = -1.5f;

    [SerializeField] private GameObject TextScoreObj;
    public bool gameOver = false;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && (Input.GetButtonDown("Jump") || Input.touchCount > 0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void addPoints() 
    {
        //TextScore.SetActive(false);
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score;
    }

    public void PlayerCrashed() 
    {
        gameOver = true;
    }
}
