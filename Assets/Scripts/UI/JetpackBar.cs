using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxFuel(int maxFuel){
        slider.maxValue = maxFuel;
        slider.value = maxFuel;
    }
    // Start is called before the first frame update
    public void setFuel(int fuel){
        slider.value = fuel;
    }
}
