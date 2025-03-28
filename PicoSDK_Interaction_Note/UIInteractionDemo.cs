using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractionDemo : MonoBehaviour
{
    public Slider slider;
    public Transform ToolBox;   //操作的对象
    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);    //将其的值进行改变
        slider.value = 0.5f;
    }

    public void OnSliderValueChanged(float value)
    {
        //根据Slider的值,设置游戏对象的缩放比例,使其随着value在0.5-1.5之间变化
        ToolBox.localScale = Vector3.one * (0.5f + value);
    }
 
}
