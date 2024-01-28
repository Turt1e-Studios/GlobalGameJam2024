using UnityEngine;
using TMPro;
using System;
using Vector3 = UnityEngine.Vector3;

public class CarrotFollow : MonoBehaviour
{
    public double score;
    public float initialTime;
    [SerializeField] private GameObject player;
    [SerializeField] private float enemySpeed = 2;
    [SerializeField] private float distanceFromPlayer = 2f;
    private float _enemySpeed;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        initialTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        score = Math.Round(Time.time - initialTime,2);
        scoreText.text = score + "";

        if (Vector3.Distance(transform.position, player.transform.position) > distanceFromPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);

        }
        else
        {
            
        }
    }

}