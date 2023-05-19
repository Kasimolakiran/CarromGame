using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarromGameManager : MonoBehaviour
{
    public GameObject botStriker;
    public GameObject playerStriker;

    private bool isPlayerTurn = true;
    private float turnDuration = 5f;
    public float turnTimer = 0f;

    private void Start()
    {
        isPlayerTurn = true;
        botStriker.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<StrikerMovement>().StrikerMovements();
                isPlayerTurn = false;
                botStriker.SetActive(true);
                turnTimer = 0f;
            }
        }
        else
        {
            if (turnTimer >= turnDuration)
            {
                ResetStrikerPosition(botStriker);

                GameObject[] whiteCoins = GameObject.FindGameObjectsWithTag("WhiteCoin");
                GameObject closestCoin = null;
                float closestDistance = Mathf.Infinity;
                foreach (GameObject whiteCoin in whiteCoins)
                {
                    float distance = Vector3.Distance(botStriker.transform.position, whiteCoin.transform.position);
                    if (distance < closestDistance)
                    {
                        closestCoin = whiteCoin;
                        closestDistance = distance;
                    }
                }

                if (closestCoin != null)
                {
                    Vector3 direction = closestCoin.transform.position - botStriker.transform.position;
                    direction.Normalize();

                    float force = Random.Range(10f, 20f);

                    Rigidbody2D strikerRigidbody = botStriker.GetComponent<Rigidbody2D>();
                    strikerRigidbody.AddForce(direction * force, ForceMode2D.Impulse);
                }

                isPlayerTurn = true;
                botStriker.SetActive(false);
            }
            else
            {
                turnTimer += Time.deltaTime;
            }
        }
    }

    private void ResetStrikerPosition(GameObject striker)
    {
        striker.transform.position = Vector3.zero;
        striker.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        striker.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }
}
