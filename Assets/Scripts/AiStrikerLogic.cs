using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStrikerLogic : MonoBehaviour
{
    public GameObject playerStriker; 
    public GameObject botStriker;
    Vector2 player;
    Vector2 bot;

    private bool isPlayerTurn = true;
    private void Start()
    {
        
        player =transform.position;
        bot = transform.position;
        isPlayerTurn = true;
        botStriker.SetActive(false); 
    }

    private void Update()
    {
        if (isPlayerTurn)
        {
            
            if (Input.GetMouseButtonDown(1))
            {
               
              
                isPlayerTurn = false;
                botStrikerReset();
                botStriker.SetActive(true); 
                playerStriker.SetActive(false); 
                StartCoroutine(BotTurnDelay());
            }
        }
    }

    private IEnumerator BotTurnDelay()
    {
       
        yield return new WaitForSeconds(2f); 

        
        playerStrikerReset();
        isPlayerTurn = true;
        botStriker.SetActive(false); 
        playerStriker.SetActive(true); 
    }
    void playerStrikerReset()
    {
        transform.position = player;

    }
    void botStrikerReset()
    {
        transform.position = bot;

    }
}
