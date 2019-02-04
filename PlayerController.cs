using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private int count;
    private int lives;
    private int score;

    public float speed;
    public Text countText;
    public Text winText;
    public Text liveText;
    public Text loseText;
    public Text scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        score = 0;
        setCountText();
        setLivesText();
        setScoreText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 250;
            setCountText();
            setScoreText();
        }
        if (other.gameObject.CompareTag("PickupBad"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            score = score - 100;
            setLivesText();
            setScoreText();
        }


    }
    void setLivesText()
    {
        liveText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "You Lose :(";
            gameObject.SetActive(false);
        }

    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString() + " / 16";
        if (count == 8)
        {
            transform.position = new Vector3(61, 0.0f, 0.0f);
        }
        if (count >= 16)
        {
            winText.text = "You Win!";
            gameObject.SetActive(false);
        }
    }
    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
