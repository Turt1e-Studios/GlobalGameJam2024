using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Note to whoever's editing this code: you don't need to add a health variable here because this class inherits from Enemy which already has health functionality.
    [SerializeField] private int speed = 1;
    [SerializeField] private float distanceFromPlayer = 5f;
    private GameObject Player;
    private Player playerScript;
    private Rigidbody testEnemyRb;
    private float enemySpeed;

    private void Awake()
    {
        health = maxHealth; // have to include this line to set health in any enemy class
        testEnemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distanceFromPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerScript.ChangeHealth(-1);
        }
    }
}