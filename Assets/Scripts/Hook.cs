using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform fallLimit;
    public float hookDownSpeed = 2.0f;
    public float hookUpSpeed = 1.0f;
    private Vector2 firstPos;
    private Vector2 Pos;
    public bool up;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
        up = false;
        hookUpSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ctrl();
        if (!up)
        {
            if(transform.position.y > fallLimit.position.y)
            {
                transform.position -= transform.up * hookDownSpeed * Time.deltaTime;

            }
        }
        else
        {
            if(transform.position.y < firstPos.y)
            {
                transform.position += transform.up * hookUpSpeed * Time.deltaTime;
            }
            else
            {
                up = false;
            }
        }
        
    }

    private void ctrl()
    {
        if (this.gameObject.name == "Hook1")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                up = true;
            }
        }
        if (this.gameObject.name == "Hook2")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                up = true;
            }
        }
        if (this.gameObject.name == "Hook3")
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                up = true;
            }
        }
        if (this.gameObject.name == "Hook4")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                up = true;
            }
        }
    }

}
