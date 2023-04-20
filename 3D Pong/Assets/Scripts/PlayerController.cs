using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    private float zRange = 8f;

    

    // Update is called once per frame
    void Update()
    {
        // Keeps the player within set boundaries
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        float verticalInput = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + transform.forward * verticalInput * speed * Time.deltaTime;

        transform.position = newPosition;
    }

}

