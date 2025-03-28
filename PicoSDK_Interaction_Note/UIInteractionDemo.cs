using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractionDemo : MonoBehaviour
{
    public Slider slider;
    public Transform ToolBox;   //�����Ķ���
    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);    //�����ֵ���иı�
        slider.value = 0.5f;
    }

    public void OnSliderValueChanged(float value)
    {
        //����Slider��ֵ,������Ϸ��������ű���,ʹ������value��0.5-1.5֮��仯
        ToolBox.localScale = Vector3.one * (0.5f + value);
    }
 
}
