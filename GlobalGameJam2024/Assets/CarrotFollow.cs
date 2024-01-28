using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CarrotFollow : MonoBehaviour
{
    public float score;
    public float initialTime;
    [SerializeField] private GameObject player;
    [SerializeField] private int enemySpeed = 2;
    [SerializeField] private float distanceFromPlayer = 2f;
    private float _enemySpeed;

    void Start()
    {
        initialTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) > distanceFromPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);

        }
        else
        {
            score = Time.time - initialTime;
        }
    }

}