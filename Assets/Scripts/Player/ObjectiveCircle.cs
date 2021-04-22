using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveCircle : MonoBehaviour
{
    public Slider slider;

    public void setMaxObj(int maxObj){
        slider.maxValue = maxObj;
        slider.value = 0;
    }
    // Start is called before the first frame update
    public void setObj(int obj){
        slider.value = obj;
    }
}
