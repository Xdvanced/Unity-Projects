using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{

    public float ballSpeed = 50; // Initial Speed of ball
    [SerializeField] float speedIncrement = 10;
    private Rigidbody rb;
    public GameObject ballGameObject;

    Vector3 lastVelocity;

    int score;
    public TMP_Text scoreDisplay;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        float zRotationOnStart = Random.Range(100f, 500f);

        
        rb.AddForce(new Vector3(9.8f * ballSpeed, 0, zRotationOnStart));
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Increment speed of ball
            ballSpeed += speedIncrement;

            score++;
            scoreDisplay.text = "" + score;
        }

        if (collision.gameObject.CompareTag("AI"))
        {
            // Increment speed of ball
            ballSpeed += speedIncrement;

            score++;
            scoreDisplay.text = "" + score;
        }

        if (collision.gameObject.CompareTag("LeftRightBorder"))
        {
            //ballGameObject.SetActive(false);
            Destroy(ballGameObject);
        }

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        lastVelocity = rb.velocity;
    }
}
