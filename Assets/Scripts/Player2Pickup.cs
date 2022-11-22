using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player2Pickup : MonoBehaviour
{
    public TextMeshProUGUI greenKeyScore;
    public int greenKeyScoreNumber;

    public GameObject player2Teleporter;
    public GameObject player2Win;
    public GameObject Player1;

    public AudioSource audioManager;
    public AudioClip key;

    private void Start()
    {
        greenKeyScoreNumber = 0;
        greenKeyScore.text = greenKeyScoreNumber.ToString();

        GetComponent<Player2Controller>().enabled = true;
    }

    private void Update()
    {
        greenKeyScore.text = greenKeyScoreNumber.ToString();

        if (greenKeyScoreNumber == 4)
        {
            player2Teleporter.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (name.Contains("GreenPlayer2"))
        {
            if (collision.gameObject.tag == "GreenKey")
            {
                Destroy(collision.gameObject);

                audioManager.PlayOneShot(key);

                greenKeyScoreNumber += 1;
                greenKeyScore.text = greenKeyScoreNumber.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Teleporter2"))
        {
            player2Win.SetActive(true);

            GetComponent<Player2Controller>().enabled = false;

            Player1.GetComponent<Player1Controller>().enabled = false;

            gameObject.SetActive(false);

            Player1.SetActive(false);
        }
    }
}