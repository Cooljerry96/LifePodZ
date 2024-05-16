using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
    private Slider energyIndicator;
    private float energyDrain = 0.1f;
     

    // Start is called before the first frame update
    void Start()
    {
        energyIndicator = GetComponent<Slider>();
    }

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Decrease Energy Indicator based on time passed from the last frame
            energyIndicator.value -= energyDrain * Time.deltaTime;
        }
    }

}
