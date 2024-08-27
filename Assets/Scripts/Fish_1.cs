using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fish_1 : MonoBehaviour
{
    private float life = 60;
    //[SerializeField] private Transform L_Wall;
    //[SerializeField] private Transform R_Wall;
    private GameObject L_Wall;
    private GameObject R_Wall;
    private float speed = 1.0f;
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
        L_Wall = GameObject.Find("L_Wall");
        R_Wall = GameObject.Find("R_Wall");
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;
        if (life < 0)
        {
            Destroy(this.gameObject);
        }
        if (GameManager.gameState == GameManager.State.Finish)
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
                Destroy(this.gameObject);
                break;
        }
    }

    private void idolMove()
    {
        if(speed >= 0)
        {
            speed -= Time.deltaTime * 2;
        }
        else
        {
            speed = 5.0f;
        }

        if (goRight)
        {
            if (transform.position.x < R_Wall.transform.position.x)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                goRight = false;
            }
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            if (transform.position.x > L_Wall.transform.position.x)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            else
            {
                goRight = true;
            }
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void caughtMove()
    {
        transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
        if (goRight)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }

        if (transform.position.y > 8)
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
                transform.position = new Vector2(collision.transform.position.x, transform.position.y);
            }
        }
    }
}
