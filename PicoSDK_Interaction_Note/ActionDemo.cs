using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionDemo : MonoBehaviour
{
    public InputActionReference Enum;   //要引用的动作
    public GameObject Target;           //进行操作的组件

    private void Start()
    {
        Enum.action.performed += OnJumpActionPerformed; //将注册好的事件追加
    }

    private void OnJumpActionPerformed(InputAction.CallbackContext obj)
    {
        Target.GetComponent<Rigidbody>().AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
    }
}
