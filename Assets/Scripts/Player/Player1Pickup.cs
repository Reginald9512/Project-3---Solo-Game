using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player1Pickup : MonoBehaviour
{
    public TextMeshProUGUI redKeyScore;
    public int redKeyScoreNumber;

    public GameObject player1Teleporter;
    public GameObject player1Win;
    public GameObject player2;

    public AudioSource audioManager;
    public AudioClip keyPickup;

    public Transform player1StartPosition;

    public void Start()
    {
        redKeyScoreNumber = 0;
        redKeyScore.text = redKeyScoreNumber.ToString();

        GetComponent<Player1Controller>().enabled = true;
    }

    public void Update()
    {
        redKeyScore.text = redKeyScoreNumber.ToString();

        if(redKeyScoreNumber == 4)
        {
            player1Teleporter.SetActive(true);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (name.Contains("RedPlayer1"))
        {
            if (collision.gameObject.tag == "RedKey")
            {
                Destroy(collision.gameObject);

                audioManager.PlayOneShot(keyPickup);

                redKeyScoreNumber += 1;
                redKeyScore.text = redKeyScoreNumber.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Teleporter1"))
        {
            player1Win.SetActive(true);

            GetComponent<Player1Controller>().enabled = false;

            player2.GetComponent<Player2Controller>().enabled = false;

            gameObject.SetActive(false);

            player2.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position = player1StartPosition.position;
        }
    }
}