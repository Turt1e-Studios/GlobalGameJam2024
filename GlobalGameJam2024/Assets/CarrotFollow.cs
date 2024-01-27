using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CarrotFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int speed = 1;
    [SerializeField] private float distanceFromPlayer = 5f;
    private float _enemySpeed;

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distanceFromPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

}