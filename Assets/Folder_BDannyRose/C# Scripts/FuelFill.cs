using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelFill : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Dash dash;

    public void SetFuelMax(float fuelMax)
    {
        slider.maxValue = fuelMax;
    }

    void SetFuel(float fuel)
    {
        slider.value = fuel;
    }

    private void FixedUpdate()
    {
        SetFuel(dash.fuel);
    }
}
