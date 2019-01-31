using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;
    public Text loseText;
    public GameObject exitRamp;
    public GameObject ramp2;
    public GameObject ramp22;
    public GameObject floor2;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;
    private GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";

        score = 0;
        SetScoreText();

        lives = 3;
        SetLivesText();

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();

            score = score + 1;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetScoreText();
            count = count + 1;
            SetCountText();

            lives = lives - 1;
            SetLivesText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
        }
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            //winText.text = "You Win!";
        }
    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12)
        {
            exitRamp.SetActive(true);
            ramp2.SetActive(true);
            ramp22.SetActive(true);
            floor2.SetActive(true);
        }
        if (score >= 20)
        {
            winText.text = "You Win!";
        }
    }

    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString();
        if(lives == 0)
        {
            Destroy(Player);
            loseText.text = "You Lost!";
            Application.Quit();
        }
    }
}