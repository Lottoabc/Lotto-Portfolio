using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public Transform Player;    //玩家的位置

    private void Update()
    {
        Vector3 PlayerPosition = new Vector3(Player.position.x,             //获得一个UICanvas需要指向的方向
            transform.position.y, Player.position.z);
        Vector3 DirectionToPlayer = transform.position - PlayerPosition;    //得到UI Canvas指向玩家的方向
        transform.rotation = Quaternion.LookRotation(DirectionToPlayer);    //将自身旋转更改为面朝玩家的方向
    }
}
