using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    
    [SerializeField] float speed = 5f; // Movement speed 
    private float border = 8f;
    public GameObject ball;

    private Vector3 targetPosition;
    private Vector3 currentVelocity;

    private void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball != null)
        {
            targetPosition.z = ball.transform.position.z;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 0.1f, speed);

            // Bot's current position
            Vector3 currentPos = transform.position;

            // Restrict movement to Z axis
            currentPos.z = Mathf.Clamp(currentPos.z, -border, border);

            // calculate direction vector between bot and ball
            Vector3 direction = ball.transform.position - transform.position;

            // Project direction vector onto only the z axis
            Vector3 directionOnZ = Vector3.ProjectOnPlane(direction, Vector3.right);

            // Make it so that the bot is always moving towards the ball
            transform.Translate(directionOnZ.normalized * speed * Time.fixedDeltaTime, Space.World);
        }
    }
}
