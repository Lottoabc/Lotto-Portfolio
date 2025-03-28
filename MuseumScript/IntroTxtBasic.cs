using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class IntroTxtBasic : MonoBehaviour
{
    // 可见距离，小于此距离则UI显示
    public float VisibleDistance;
    // 对Player的引用
    protected Player player;
    // 对游戏对象本身Transform的引用
    protected Transform _transform;
    // 具体承载UI元素的Canvas
    public GameObject IntroCanvas;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // 初始状态下隐藏Canvas
        IntroCanvas.SetActive(false);
        // 获取Player的实例引用
        player = Player.instance;
        // 获取游戏对象的Transform引用
        _transform = transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // 得到体验者与游戏对象的距离
        float dis = Vector3.Distance(player.hmdTransform.position, _transform.position);
        // 如果小于设定的可见距离，则显示UI
        if (dis < VisibleDistance)
        {
            if (!IntroCanvas.activeInHierarchy)
                IntroCanvas.SetActive(true);
        }
        else // 如果大于设定的距离，则隐藏UI
        {
            if (IntroCanvas.activeInHierarchy)
                IntroCanvas.SetActive(false);
        }
    }
}
