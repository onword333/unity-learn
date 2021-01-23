using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour
{

    public static GameControll instance;
    
    public float scrollSpeed = -1.5f;

    [SerializeField] private GameObject TextScore;
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
        if (gameOver && Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void addPoints() 
    {
        TextScore.SetActive(false);
    }

    public void PlayerCrashed() 
    {
        gameOver = true;  
    }
}
