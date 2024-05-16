using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    private float countDown = 15;
    public bool isLevelActive;
    public GameObject startTimer;

    // Start is called before the first frame update
    void Start()
    {
        isLevelActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Start Timer Coroutine
        StartCoroutine(StartCoutdownRoutine());
    }

    //Timer Coroutine
    IEnumerator StartCoutdownRoutine()
    {
        if (countDown > 0.0f)
        {
            countDown -= Time.deltaTime;
            countDownText.text = "Start In: " + countDown.ToString("F0");
        }
        else
        {
            startTimer.gameObject.SetActive(false);
        }

        yield return countDownText.text;

        
    }

}
