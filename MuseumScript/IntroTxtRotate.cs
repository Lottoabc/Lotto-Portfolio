using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTxtRotate : IntroTxtBasic
{
    // ��Ϸ���󡰿��򡱵�λ�õ�
    private Vector3 lookAtPosition = Vector3.zero;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //���Ŀ������꣬��ʹ�������ߵ�x��z���꣬y�������ṩ����ֻ��y�������������ת
        lookAtPosition.x = player.hmdTransform.position.x;
        lookAtPosition.y = _transform.position.y;
        lookAtPosition.z = player.hmdTransform.position.z;
        //����������
        _transform.LookAt(lookAtPosition);
    }
}
