using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Michsky.UI.ModernUIPack;
public class introTxtwithBotton : MonoBehaviour
{
    public GameObject infoPanel;    //用于展示文字介绍的Panel，交互过程中对其进行显示和隐藏
    public ButtonManagerIcon ButtonManager;     //按钮管理，在交互过程中进行图标切换
    public Sprite InfoIcon;        //文字隐藏状态下的按钮图标 
    public Sprite CloseIcon;    //文字显示状态下的按钮图标
    private bool isShow = false;    //文字状态标志位
    // Start is called before the first frame update
    void Start()
    {
        infoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInfoButtonClick()
    {
        if(isShow)
        {
            CloseIntro();
        }
        else
        {
            ShowIntro();
        }
    }

    private void ShowIntro()
    {
        infoPanel.SetActive(true);  //先将文字功能显示出来
        infoPanel.transform.localScale = Vector3.zero;   //文字Panel缩放设置为0，由此开始缓动
        infoPanel.transform.DOScale(Vector3.one,0.3f);  //文字Panel做0.3缓动，缩放从0到1 
        ButtonManager.buttonIcon = CloseIcon;  //设置按键图标
        ButtonManager.UpdateUI();
        isShow = true;  //设置标志位
    }

    public void CloseIntro()
    {       //文字内容做0.3秒的缓动，从原始缩放从1到0
        Tweener tweener = infoPanel.transform.DOScale(Vector3.zero, 0.3f);
        tweener.onComplete = () => { infoPanel.SetActive(false); }; //缓动结束后将文字隐藏
        ButtonManager.buttonIcon = InfoIcon;
        ButtonManager.UpdateUI();   //更新按钮的图标
        isShow = false;     //设置标志位
    }
}
