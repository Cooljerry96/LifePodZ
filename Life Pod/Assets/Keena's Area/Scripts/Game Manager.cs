using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private StartButton startButton;
    public GameObject startMenu;
    public GameObject levels;
    public GameObject startTimer;
    public GameObject hyperSpace;
    public bool isGameActive;

    public TextMeshProUGUI countDownText;
    private float countDown = 15;

    [SerializeField] private UnityEngine.UI.Button[] allLevels;
    private bool pressed;


    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Start").GetComponent<StartButton>();
        
    }

    private void Awake()
    {
        int i = 0;
        foreach (UnityEngine.UI.Button btn in allLevels)
        {
            ListenerHandler(btn, i);

            i++;
        }
    }
    private void ListenerHandler(UnityEngine.UI.Button btn, int index)
    {
        btn.onClick.AddListener(LevelSelection);
    }

    public void StartGame()
    {
        isGameActive = true;
        startMenu.gameObject.SetActive(false);
        levels.gameObject.SetActive(true);
        
    }

    public void LevelSelection()
    {
        levels.gameObject.SetActive(false);
        pressed = true;
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
        if (pressed == true)
        {
            StartCoroutine(StartCoutdownRoutine());
            startTimer.gameObject.SetActive(true);
            hyperSpace.gameObject.SetActive(false);

        }
    }
}
