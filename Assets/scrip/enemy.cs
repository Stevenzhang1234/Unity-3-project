using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public float waitTime = 5.0f;
    public int damage = 10;
    public playerInfo info;
    public playerController player;
    // Start is called before the first frame update
    void Start()
    {
        
        if(player == null)
        {
            player = GameObject.Find("player").GetComponent<playerController>();        
        }
        if(info == null){
            info = GameObject.Find("PlayerInfo").GetComponent<playerInfo>();
        }
        StartCoroutine(moveEnemy());
    }   
    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(moveEnemy());
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Destroy(other.gameObject);
            // //stop game
            // Time.timeScale = 0;

            //playerController.health -= damage;

            player.ChangeHealth(25);

        }
        else if(other.gameObject.tag == "Bullet")
        {
            //playerController.score += 100;
            //info.score += 100;
            print("add 100 to score");
            player.ChangeScore(100);
            Destroy(this.gameObject);
        }
    }

    void spawnEnemy()
    {
        this.transform.position = new Vector3(Random.Range(9, -9),Random.Range(-2,4),0);
    }

    IEnumerator moveEnemy(){
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            spawnEnemy();
        }
        
    }
}
