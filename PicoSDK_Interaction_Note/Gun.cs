using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Animator GunAnimatorController;
    private AudioSource GunAudioSource;

    public GameObject BulletShellPrefab;   //用于生成弹壳的预制体
    public Transform ShellEjectPoint;      //弹壳弹出的位置点
    public float DelayTime;                //弹壳弹出的延时时间

    public GameObject MuzzleFlash;          //枪口火焰特效所在的游戏对象
    public GameObject BulletTracer;         //子弹轨迹特效所在的游戏对象
    private ParticleSystem bulletTracer;     //子弹轨迹的粒子特效
    private ParticleSystem[] muzzleFlashList;//枪口火焰的特效列表

    public Transform MuzzlePoint;           //枪口的位置
    public GameObject BulletHolePrefab;     //弹孔的预制体

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();  //获取XRGrabInteractable组件
        grabInteractable.activated.AddListener(Shoot);          //添加activated事件的监听器,使被Activated就调用Shoot

        GunAnimatorController = GetComponentInChildren<Animator>(); //获取Animator用于播放动画

        GunAudioSource = GetComponent<AudioSource>();

        bulletTracer = BulletTracer.GetComponent<ParticleSystem>();
        muzzleFlashList = MuzzleFlash.GetComponentsInChildren<ParticleSystem>();
    }

    private void Shoot(ActivateEventArgs arg0)
    {
        GunAnimatorController.SetTrigger("Fire");
        GunAudioSource.Play();
        StartCoroutine((EjectBulletShell()));

        foreach(ParticleSystem particleItem in muzzleFlashList) //遍历枪口火焰的特效
        {
            particleItem.Play();
        }

        bulletTracer.Play();    //播放子弹轨迹的特效

        TakeDamage();
    }

    private void TakeDamage()
    {
        RaycastHit HitInformation;  //用于存储射线检测的结果

        if(Physics.Raycast(MuzzlePoint.position, MuzzlePoint.forward, out HitInformation))  //如果射线面前有目标
        {
            GameObject bulletHole = Instantiate(BulletHolePrefab,                           //将弹孔进行生成
                HitInformation.point + HitInformation.normal * 0.001f,
                Quaternion.LookRotation(HitInformation.normal));
        }

    }

    private IEnumerator EjectBulletShell()
    {
        Quaternion shellSpawnRotation = Quaternion.Euler(Random.Range(-30,30),    //这里使用一个四元数来存储旋转角度
            Random.Range(-30,30),Random.Range(-30,30));
        GameObject shell = Instantiate(BulletShellPrefab, 
            ShellEjectPoint.position, shellSpawnRotation);                  //使用Instantiate复制一个弹壳的实例

        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();         //获取弹壳的刚体组件
        shellRigidbody.velocity = new Vector3(Random.Range(0.5f, 1.5f),     //设置弹壳(Rigidbody)的速度
            Random.Range(0.9f, 1.1f), Random.Range(-0.85f, 1.5f));
        shellRigidbody.angularVelocity = new Vector3(Random.Range(-10,10),  //设置弹壳的旋转速度
            Random.Range(-10,10),Random.Range(-10,10));

        yield return new WaitForSeconds(DelayTime);
    }
}
