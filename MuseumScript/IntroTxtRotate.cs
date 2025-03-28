using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTxtRotate : IntroTxtBasic
{
    // 游戏对象“看向”的位置点
    private Vector3 lookAtPosition = Vector3.zero;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //获得目标点坐标，仅使用体验者的x和z坐标，y由自身提供，从只从y轴跟随体验者旋转
        lookAtPosition.x = player.hmdTransform.position.x;
        lookAtPosition.y = _transform.position.y;
        lookAtPosition.z = player.hmdTransform.position.z;
        //看向体验者
        _transform.LookAt(lookAtPosition);
    }
}
