using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    public bool pressed;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGameButton);
    }

    void StartGameButton()
    {        
        gameManager.StartGame();
        pressed = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
