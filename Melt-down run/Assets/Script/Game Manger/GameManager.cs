using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject spawnObject;
    //public GameObject spawnObject2;
    //public GameObject spawnObject3;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns;

    [SerializeField]
    public float speedMultiplier;
    //private float distance;

    //public TMP_Text DistanceUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DistanceUI.TMP

        speedMultiplier += Time.deltaTime * 0.1f;

        timer += Time.deltaTime;
        if(timer > timeBetweenSpawns) 
        {
            timer = 0;
            int randNum = Random.Range(0, 3);
            Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }
}
