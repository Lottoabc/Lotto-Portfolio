using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sculpture : MonoBehaviour
{
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;     //将transform赋值到_transform，这么做减少了性能的消耗
        MoveUpAndDown();
    }   

    // Update is called once per frame
    private void MoveUpAndDown()
    {
        Vector3 upDestination = _transform.position + Vector3.up * 2.5f;    //最终位置为游戏对象向上移动0.1米
        _transform.DOMove(upDestination, 3.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        //                最终位置     花费3秒 设置循环                设置缓动类型         
        //yoyo循环为游戏对象到达最终的的地点会开始返回          InOutSine为到终点时进行减速运动
    }
}
