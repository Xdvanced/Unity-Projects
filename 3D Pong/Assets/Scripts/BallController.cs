using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{

    [SerializeField] float speed = 30; // Initial Speed of ball
    [SerializeField] float speedIncrement = 5f;
    private Rigidbody rb;
    public GameObject ballGameObject;

    int score;
    public TMP_Text scoreDisplay;

    void Start()
    {
        float zRotationOnStart = Random.Range(100f, 500f);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(9.8f * speed, 0, zRotationOnStart));
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Increment speed of ball
            speed += speedIncrement;
        }

        if (collision.gameObject.CompareTag("AI"))
        {
            // Increment speed of ball
            speed += speedIncrement;
        }

        if (collision.gameObject.CompareTag("LeftRightBorder"))
        {
            //ballGameObject.SetActive(false);
            Destroy(ballGameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            score++;
            scoreDisplay.text = "" + score;
        }

        if (collision.gameObject.CompareTag("AI"))
        {
            score++;
            scoreDisplay.text = "" + score;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
