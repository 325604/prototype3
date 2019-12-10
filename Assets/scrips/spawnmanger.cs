using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanger : MonoBehaviour
{
    public GameObject Obstacleprefeb;
     private Vector3 spawnPos = new Vector3(25,0,0);
     private float startDalay =2;
     private float repeatRate = 2;
     private playercontrol playercontrolerscript;
         
    // Start is called before the first frame update
    void Start()
    {
        playercontrolerscript = GameObject.Find("player").GetComponent<playercontrol>();
        InvokeRepeating("SpawnObstacle", startDalay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void SpawnObstacle ()
    {
        if (playercontrolerscript.GameOver == false)
        { 
            Instantiate(Obstacleprefeb, spawnPos, Obstacleprefeb.transform.rotation); 
        }
     
    }
}
