using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public int enemiesPoolSize = 5;
    public GameObject enemiesPrefab;
    public float spanwRate = 4f;

    private Vector2 objectPoolPosition = new Vector2(-15f, -7f);
    private GameObject[] enemies;
    private float timeSinceLastSpawned;
    private float spawnYPosition = -3f;
    private int currentEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[enemiesPoolSize];
        for (int i = 0; i < enemiesPoolSize; i++)
        {
            enemies[i] = (GameObject) Instantiate(enemiesPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControll.instance.gameOver == false && timeSinceLastSpawned >= spanwRate)
        {
            Rigidbody2D rb2d = enemies[currentEnemy].GetComponent<Rigidbody2D>();
            AudioSource audioSource = enemies[currentEnemy].GetComponent<AudioSource>();
            float spawnXPosition = Random.Range(11f, 17f);

            audioSource.Play();

            timeSinceLastSpawned = 0;
            
            enemies[currentEnemy].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            rb2d.velocity = Vector2.zero;
         
            currentEnemy++;
            if (currentEnemy >= enemiesPoolSize)
            {
                currentEnemy = 0;
            }
        }
    }
}
