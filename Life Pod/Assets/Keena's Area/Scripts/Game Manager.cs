using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private StartButton startButton;
    public GameObject startMenu;
    public GameObject startTimer;
    public GameObject hyperSpace;
    public bool isGameActive;

    public TextMeshProUGUI countDownText;
    private float countDown = 15;


    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Start").GetComponent<StartButton>();
    }

    public void StartGame()
    {
        isGameActive = true;
        startMenu.gameObject.SetActive(false);
        
    }
    IEnumerator StartCoutdownRoutine()
    {
        if (countDown > 0.0f)
        {
           countDown -= Time.deltaTime;
           countDownText.text = "Start In: " + countDown.ToString("F0");
        }
        yield return  countDownText.text;
    }

  
    

    // Update is called once per frame
    void Update()
    {
        if (startButton.pressed == true)
        {
            StartCoroutine(StartCoutdownRoutine());
            startTimer.gameObject.SetActive(true);
            hyperSpace.gameObject.SetActive(false);

        }
    }
}
