using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}
