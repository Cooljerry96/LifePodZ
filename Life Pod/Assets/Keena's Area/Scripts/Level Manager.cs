using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Timer stuff
    public TextMeshProUGUI countDownText;
    public float countDown = 15;
    public GameObject startTimer;

    //Energy Stuff
    private EnergyScript energyScript;
    public GameObject energySlider;
    private RectTransform energySliderRect;

    //Line Drawer stuff
    public GameObject lineDrawerObject;
    private LinesDrawer lineDrawer;

    //Bools
    public bool isLevelActive;
    public bool isEnergyOut;

    //Variables
    private float starLevel;
    private float oneStar = 0.34f;
    private float twoStar = 0.67f;
    private float threeStar = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        //Take Energy Script from slider object
        energyScript = energySlider.GetComponent<EnergyScript>();
        energySliderRect = energySlider.GetComponent<RectTransform>();

        //Take LineDrawer script from Line Drawer object
        lineDrawer = lineDrawerObject.GetComponent<LinesDrawer>();

        //Is active bool
        isLevelActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If the energy or timer runs out stop drawing
        if (energyScript.isEnergyOut == true || countDown <=0)
        {
            lineDrawer.EndDraw();
        }

        //Start Timer Coroutine
        StartCoroutine(StartCoutdownRoutine());
    }

    //Timer Coroutine
    IEnumerator StartCoutdownRoutine()
    {
        //Math for decreasing the timer
        if (countDown > 0.0f)
        {
            countDown -= Time.deltaTime;
            countDownText.text = "Start In: " + countDown.ToString("F0");
        }
        //This does a lot maybe make another coRoutine?
        else
        {
            //Turn the timer graphic and energy drain script off
            startTimer.SetActive(false);
            energyScript.enabled = false;

            //Shrink Energy Bar
            energySliderRect.localScale -= new Vector3(1,1,1) * Time.deltaTime * 2;
            if (energySliderRect.localScale.x <= 0)
            {
                energySlider.SetActive(false);
            }
            
            //Save Star Rating
            yield return energyScript.energyIndicator.value;
            if (energyScript.energyIndicator.value <= oneStar)
            {
                starLevel = 1;
                Debug.Log(starLevel);
            }
            if (energyScript.energyIndicator.value <= twoStar && energyScript.energyIndicator.value > oneStar)
            {
                starLevel = 2;
                Debug.Log(starLevel);
            }
            if(energyScript.energyIndicator.value <=threeStar && energyScript.energyIndicator.value >twoStar)
            {
                starLevel = 3;
                Debug.Log(starLevel);
            }
        }

        //Return countdown as text mesh
        yield return countDownText.text;
    }

}
