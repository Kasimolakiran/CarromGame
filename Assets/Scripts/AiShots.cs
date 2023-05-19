using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShots : MonoBehaviour
{
     public GameObject targetCoin;
     // GameObject targetCoin1;
     //GameObject targetCoin2;
    public Rigidbody2D strikerRigidbody; 
    //Vector2 value;

    private float forceMultiplier = 10f; 

    private void Start()
    {
        //value = transform.position;
        //Debug.Log(value);
        // Find the target coin
        targetCoin = GameObject.FindGameObjectWithTag("Coins");
        //targetCoin1 = GameObject.FindGameObjectWithTag("Queen");
        //targetCoin2 = GameObject.FindGameObjectWithTag("Coins");
    }

    private void Update()
    {
        Vector3 direction = targetCoin.transform.position - transform.position;
        direction.Normalize();

        // Calculate the force based on the distance to the target coin
        float distance = Vector3.Distance(targetCoin.transform.position, transform.position);
        float force = distance * forceMultiplier;

        // Apply force to the striker in the calculated direction
        strikerRigidbody.AddForce(direction * force);
       // StrikerReset();
    }
    //void shot1()
    //{
    //    Vector3 direction = targetCoin.transform.position - transform.position;
    //    direction.Normalize();

    //    Calculate the force based on the distance to the target coin
    //    float distance = Vector3.Distance(targetCoin.transform.position, transform.position);
    //    float force = distance * forceMultiplier;

    //    Apply force to the striker in the calculated direction
    //    strikerRigidbody.AddForce(direction * force);
    //}
    //void shot2()
    //{
    //    Vector3 direction = targetCoin1.transform.position - transform.position;
    //    direction.Normalize();

    //    Calculate the force based on the distance to the target coin
    //    float distance = Vector3.Distance(targetCoin1.transform.position, transform.position);
    //    float force = distance * forceMultiplier;

    //    Apply force to the striker in the calculated direction
    //    strikerRigidbody.AddForce(direction * force);
    //}
    //void shot3()
    //{
    //    Vector3 direction = targetCoin2.transform.position - transform.position;
    //    direction.Normalize();

    //    Calculate the force based on the distance to the target coin
    //    float distance = Vector3.Distance(targetCoin2.transform.position, transform.position);
    //    float force = distance * forceMultiplier;

    //    Apply force to the striker in the calculated direction
    //    strikerRigidbody.AddForce(direction * force);
    //}
    //void StrikerReset()
    //{
    //    transform.position = value;
    //}

}
