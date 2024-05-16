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
    public GameObject hyperSpace;
    
    public bool isGameActive;

    /*public TextMeshProUGUI countDownText;
      public GameObject startTimer;
      private float countDown = 15;*/

    [SerializeField] private UnityEngine.UI.Button[] allLevels;
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        //assign Start Button in Unity to the variable
        startButton = GameObject.Find("Start").GetComponent<StartButton>();
    }

    private void Awake()
    {
        // For statement adding a handler to each button in Button array for the ammount of levels
        int i = 0;
        foreach (UnityEngine.UI.Button btn in allLevels)
        {
            ListenerHandler(btn, i);

            i++;
        }
    }
    // Set the Class to call when button is pressed
    private void ListenerHandler(UnityEngine.UI.Button btn, int index)
    {
        btn.onClick.AddListener(LevelSelection);
    }

    private void CallLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    //When the start button is pressed
    public void StartGame()
    {
        isGameActive = true;
        startMenu.gameObject.SetActive(false);
        levels.gameObject.SetActive(true);
    }

    //When Level is selected
    public void LevelSelection()
    {
        levels.gameObject.SetActive(false);
        pressed = true;
    }
 
    // Update is called once per frameC
    void Update()
    {

        if (pressed == true)
        {
            CallLevelOne();
        }

    }
}
