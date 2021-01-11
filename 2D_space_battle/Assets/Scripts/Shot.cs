using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public int damage = 1;

    /// <summary>
    /// Снаряд наносит повреждения игроку или врагам ?
    /// </summary>
    public bool isEnemyShot = false;


    // Start is called before the first frame update
    void Start()
    {
        // проблема в том, что после того как gameObject уничтожен
        // невозможно больше стрелять
        //Destroy(this.gameObject, 20); // 20 секунд, 
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
