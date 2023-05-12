using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectscript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] 
    public float speed;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * (speed + gameManager.speedMultiplier);
    }
}
