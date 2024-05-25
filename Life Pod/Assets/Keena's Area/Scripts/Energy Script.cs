using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
    public Slider energyIndicator;
    private float energyDrain = 0.1f;
    public bool isEnergyOut;


    // Start is called before the first frame update
    void Start()
    {
        energyIndicator = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //On button click decrease Energy Indicator based on time passed from the last frame
        if (Input.GetMouseButton(0))
        {
            energyIndicator.value -= energyDrain * Time.deltaTime;
        }

        //Turn off bool.
        if (energyIndicator.value <= 0)
        {
            isEnergyOut = true;
        }
    }

}
