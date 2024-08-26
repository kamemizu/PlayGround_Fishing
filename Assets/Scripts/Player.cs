using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(name == "Player1")
        {
            Debug.Log("â¡éZÅIÅIÅI");
            if (collision.gameObject.tag == "Fish_1")
            {
                GameManager.p1Score += 1;
            }
            if (collision.gameObject.tag == "Fish_5")
            {
                GameManager.p1Score += 5;
            }
            if (collision.gameObject.tag == "Fish_10")
            {
                GameManager.p1Score += 10;
            }
            if (collision.gameObject.tag == "Fish_15")
            {
                GameManager.p1Score += 15;
            }
            if (collision.gameObject.tag == "Fish_30")
            {
                GameManager.p1Score += 30;
            }
        }
        if (name == "Player2")
        {
            if (collision.gameObject.tag == "Fish_1")
            {
                GameManager.p2Score += 1;
            }
            if (collision.gameObject.tag == "Fish_5")
            {
                GameManager.p2Score += 5;
            }
            if (collision.gameObject.tag == "Fish_10")
            {
                GameManager.p2Score += 10;
            }
            if (collision.gameObject.tag == "Fish_15")
            {
                GameManager.p2Score += 15;
            }
            if (collision.gameObject.tag == "Fish_30")
            {
                GameManager.p2Score += 30;
            }
        }
        if (name == "Player3")
        {
            if (collision.gameObject.tag == "Fish_1")
            {
                GameManager.p3Score += 1;
            }
            if (collision.gameObject.tag == "Fish_5")
            {
                GameManager.p3Score += 5;
            }
            if (collision.gameObject.tag == "Fish_10")
            {
                GameManager.p3Score += 10;
            }
            if (collision.gameObject.tag == "Fish_15")
            {
                GameManager.p3Score += 15;
            }
            if (collision.gameObject.tag == "Fish_30")
            {
                GameManager.p3Score += 30;
            }
        }
        if (name == "Player4")
        {
            if (collision.gameObject.tag == "Fish_1")
            {
                GameManager.p4Score += 1;
            }
            if (collision.gameObject.tag == "Fish_5")
            {
                GameManager.p4Score += 5;
            }
            if (collision.gameObject.tag == "Fish_10")
            {
                GameManager.p4Score += 10;
            }
            if (collision.gameObject.tag == "Fish_15")
            {
                GameManager.p4Score += 15;
            }
            if (collision.gameObject.tag == "Fish_30")
            {
                GameManager.p4Score += 30;
            }
        }

    }

}
