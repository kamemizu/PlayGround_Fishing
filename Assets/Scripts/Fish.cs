using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private Transform L_Wall;
    [SerializeField] private Transform R_Wall;
    private float speed = 5.0f;
    private float upSpeed;
    private bool goRight;

    public enum State
    {
        Idol,
        Caught,
        Finish
    }
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        goRight = true;
        state = State.Idol;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameState == GameManager.State.Finish)
        {
            state = State.Finish;
        }
        switch (state)
        {
            case State.Idol:
                idolMove();
                break;
            case State.Caught:
                caughtMove();
                break;
            case State.Finish:
                break;
        }
    }

    private void idolMove()
    {
        if (goRight)
        {
            if (transform.position.x < R_Wall.position.x)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                goRight = false;
            }
        }
        else
        {
            if (transform.position.x > L_Wall.position.x)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            else
            {
                goRight = true;
            }
        }
    }

    private void caughtMove()
    {
        transform.position += transform.up * upSpeed * Time.deltaTime;
        if(transform.position.y > 8)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("“–‚½‚Á‚½");
        if (collision.gameObject.tag == "Hook")
        {
            if (collision.gameObject.GetComponent<Hook>().up == true)
            {
                state = State.Caught;
                upSpeed = collision.gameObject.GetComponent<Hook>().hookUpSpeed;
            }
        }
    }
}
