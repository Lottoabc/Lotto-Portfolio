using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using System;

public class UImanager : MonoBehaviour
{
    public GameObject LaserBeam;    //CurvedUI的激光指针
    public LayerMask LayerMask;    //选择能被射线集中的图层
    public Transform RayOriginTrans;    //射线发射的出发点

    public Transform MenuUITrans;   //系统菜单
    public float MenuUIDistance = 5.5f;   //菜单显示在体验者身前距离
    private bool isMenuShow = false;    //菜单显示标志位，默认记录不显示

    public Slider TemperaturesSlider;   //色温调节Slider,数值范围：-15~15
    public Slider HueSlider;    //色调调节Slider，数值范围:-10~10
    public Slider ExposureSlider;   //曝光调节Slider，数值范围:0~2
    public Slider StustionSlider;   //饱和度Slider，数值范围-98~20

    // Start is called before the first frame update
    void Start()
    {
        MenuUITrans.gameObject.SetActive(false); //初始状态下让菜单隐藏
        SteamVR_Actions.default_Menu.onStateUp += Default_Menu_onStateUp;

        //添加监听器
        TemperaturesSlider.onValueChanged.AddListener(ChangeTemperature);
        HueSlider.onValueChanged.AddListener(ChangeHue);
        ExposureSlider.onValueChanged.AddListener(ChangeExposure);
        StustionSlider.onValueChanged.AddListener(ChangeStustion);
    }

    private void ChangeStustion(float value)
    {
        GameManager.Instance.ChangeStustion(value);
    }

    private void ChangeExposure(float value)
    {
        GameManager.Instance.ChangeExposure(value);
    }

    private void ChangeHue(float value)
    {
        GameManager.Instance.ChangeHue(value);
    }

    private void ChangeTemperature(float value)
    {
        GameManager.Instance.ChangeTemperature(value);
    }

    private void Default_Menu_onStateUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        isMenuShow = !isMenuShow; //显示状态置反
        MenuUITrans.gameObject.SetActive(isMenuShow); //显示或隐藏菜单

        if(isMenuShow) //如果菜单显示
        {       //设定菜单界面位置为体验者位置+世界空间位置，此时不在体验者的“面前”
            Transform playerHMDTrans = Player.instance.hmdTransform;   //使用头显的位置来代替体验者的位置
            MenuUITrans.position = playerHMDTrans.position + Vector3.forward * MenuUIDistance;      //让菜单的位置移动到体验者的位置+设置显示距离的值
            MenuUITrans.RotateAround(playerHMDTrans.position, Vector3.up, playerHMDTrans.rotation.eulerAngles.y);       //让沿着y轴方向旋转，给到的旋转角度就是y轴方向的旋转角度
         
        }
        else
        {
            MenuUITrans.rotation = Quaternion.Euler(Vector3.zero); //让旋转的角度归零
        }
    }

    // Update is called once per frame
    void Update()
    {       //从手柄控制器发出，长度为无限延伸，仅在UI层品检测射线碰撞
        RaycastHit hit;     //检测射线是否有发生碰撞体积                                LayerMask.value为选择的图层
        if (Physics.Raycast(RayOriginTrans.position,RayOriginTrans.forward,out hit,Mathf.Infinity,LayerMask.value))     
        {                   //发射的位置             发射的方向       向外输出一个hit  设置射线的长度为无穷
            LaserBeam.SetActive(true);
        }
        else
        {
            LaserBeam.SetActive(false);
        }
    
    }
    public void CloseMenu()
    {
        isMenuShow = false; //设置标志位
        MenuUITrans.gameObject.SetActive(false);  //隐藏菜单
        MenuUITrans.transform.rotation = Quaternion.Euler(Vector3.zero);    //菜单旋转角度归零
    }
    //重置特效数据
    public void ResetPostProcessing()
    {   //界面中的Slider回到默认值对应位置,将有效值赋值为默认值
        HueSlider.value = GameManager.Instance.defaultHue;
        ExposureSlider.value = GameManager.Instance.defaultExposure;
        TemperaturesSlider.value = GameManager.Instance.defaultTemperature;
        StustionSlider.value = GameManager.Instance.defaultStatuation;
        GameManager.Instance.ResetPostProcessing(); //调用ResetPostProcessing这个函数
    }
}
