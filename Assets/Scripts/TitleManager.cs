using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private float inGameTimer = 60.0f;
    [SerializeField] private GameObject fish_1;
    [SerializeField] private GameObject fish_5;
    [SerializeField] private GameObject fish_10;
    [SerializeField] private GameObject fish_15;
    [SerializeField] private GameObject fish_30;
    private float fishInterval = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fishInterval -= Time.deltaTime;
        if (fishInterval < 0)
        {
            CreateFish();
            fishInterval = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void CreateFish()
    {
        int rndFish = UnityEngine.Random.Range(0, 20);
        int rndX = UnityEngine.Random.Range(0, 2);
        float x = -10;
        if (rndX == 1)
        {
            x = 10;
        }
        float rndY = UnityEngine.Random.Range(-4, 1);
        if (rndFish >= 0 && rndFish <= 9)
        {
            Instantiate(fish_1, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish >= 10 && rndFish <= 13)
        {
            Instantiate(fish_5, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish >= 14 && rndFish <= 16)
        {
            Instantiate(fish_10, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish >= 17 && rndFish <= 18)
        {
            Instantiate(fish_15, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish == 19)
        {
            Instantiate(fish_30, new Vector2(x, rndY), Quaternion.identity);
        }
    }
}
