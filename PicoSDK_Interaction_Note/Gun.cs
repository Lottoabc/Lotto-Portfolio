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

    public GameObject BulletShellPrefab;   //�������ɵ��ǵ�Ԥ����
    public Transform ShellEjectPoint;      //���ǵ�����λ�õ�
    public float DelayTime;                //���ǵ�������ʱʱ��

    public GameObject MuzzleFlash;          //ǹ�ڻ�����Ч���ڵ���Ϸ����
    public GameObject BulletTracer;         //�ӵ��켣��Ч���ڵ���Ϸ����
    private ParticleSystem bulletTracer;     //�ӵ��켣��������Ч
    private ParticleSystem[] muzzleFlashList;//ǹ�ڻ������Ч�б�

    public Transform MuzzlePoint;           //ǹ�ڵ�λ��
    public GameObject BulletHolePrefab;     //���׵�Ԥ����

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();  //��ȡXRGrabInteractable���
        grabInteractable.activated.AddListener(Shoot);          //���activated�¼��ļ�����,ʹ��Activated�͵���Shoot

        GunAnimatorController = GetComponentInChildren<Animator>(); //��ȡAnimator���ڲ��Ŷ���

        GunAudioSource = GetComponent<AudioSource>();

        bulletTracer = BulletTracer.GetComponent<ParticleSystem>();
        muzzleFlashList = MuzzleFlash.GetComponentsInChildren<ParticleSystem>();
    }

    private void Shoot(ActivateEventArgs arg0)
    {
        GunAnimatorController.SetTrigger("Fire");
        GunAudioSource.Play();
        StartCoroutine((EjectBulletShell()));

        foreach(ParticleSystem particleItem in muzzleFlashList) //����ǹ�ڻ������Ч
        {
            particleItem.Play();
        }

        bulletTracer.Play();    //�����ӵ��켣����Ч

        TakeDamage();
    }

    private void TakeDamage()
    {
        RaycastHit HitInformation;  //���ڴ洢���߼��Ľ��

        if(Physics.Raycast(MuzzlePoint.position, MuzzlePoint.forward, out HitInformation))  //���������ǰ��Ŀ��
        {
            GameObject bulletHole = Instantiate(BulletHolePrefab,                           //�����׽�������
                HitInformation.point + HitInformation.normal * 0.001f,
                Quaternion.LookRotation(HitInformation.normal));
        }

    }

    private IEnumerator EjectBulletShell()
    {
        Quaternion shellSpawnRotation = Quaternion.Euler(Random.Range(-30,30),    //����ʹ��һ����Ԫ�����洢��ת�Ƕ�
            Random.Range(-30,30),Random.Range(-30,30));
        GameObject shell = Instantiate(BulletShellPrefab, 
            ShellEjectPoint.position, shellSpawnRotation);                  //ʹ��Instantiate����һ�����ǵ�ʵ��

        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();         //��ȡ���ǵĸ������
        shellRigidbody.velocity = new Vector3(Random.Range(0.5f, 1.5f),     //���õ���(Rigidbody)���ٶ�
            Random.Range(0.9f, 1.1f), Random.Range(-0.85f, 1.5f));
        shellRigidbody.angularVelocity = new Vector3(Random.Range(-10,10),  //���õ��ǵ���ת�ٶ�
            Random.Range(-10,10),Random.Range(-10,10));

        yield return new WaitForSeconds(DelayTime);
    }
}
