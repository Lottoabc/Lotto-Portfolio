using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionDemo : MonoBehaviour
{
    public InputActionReference Enum;   //Ҫ���õĶ���
    public GameObject Target;           //���в��������

    private void Start()
    {
        Enum.action.performed += OnJumpActionPerformed; //��ע��õ��¼�׷��
    }

    private void OnJumpActionPerformed(InputAction.CallbackContext obj)
    {
        Target.GetComponent<Rigidbody>().AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
    }
}
