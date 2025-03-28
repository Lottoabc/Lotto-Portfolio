using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using UnityEngine.Video;
using DG.Tweening;

public class video_controller : MonoBehaviour
{
    public VideoPlayer ArtVideo;    //����������������
    private Vector3 videoOriginScale;   //�����������ĳ�ʼ����
    public Sprite PlayIcon; //ʹ���زİ�Play
    public Sprite StopIcon; //��ʹ���زİ�Cancel Bold
    public ButtonManagerIcon ButtonManager; //��ť������
    public AudioSource Museum_BGM;      //�������������ڹ���BGM
    private bool isPlaying = false; //��¼��Ƶ�Ĳ���״̬

    // Start is called before the first frame update
    void Start()
    {
        videoOriginScale = ArtVideo.transform.localScale;   //��ȡ��Ƶ����ԭʼ����
        ArtVideo.gameObject.SetActive(false);   //Ĭ������
        ArtVideo.Stop();    //Ĭ����Ƶ������
    }

    public void OnButtonClick() //���ư�ť���������
    {
        if (isPlaying)  //������ڲ��ţ�����ر�
        {
            Museum_BGM.UnPause();   //�ر�bgm
            StopVideo();
            
        }
        else  //���û�н��в��ţ�����ʼ����
        {
            Museum_BGM.Pause();     //����bgm
            PlayVideo();
        }

        isPlaying = !isPlaying;
    }

    private void PlayVideo()
    {
        ArtVideo.gameObject.SetActive(true); //��ʾ��������Ƶ����Ϸ����

        ArtVideo.transform.localScale = new Vector3(0f, videoOriginScale.y, videoOriginScale.z);    //�������Ϸ�����x�����ϴ�0����ʼ���������ŵĻ���
        ArtVideo.GetComponent<MeshRenderer>().material.color = Color.black;
                                                                               //��onComplete����¼�����ָ��һ��������������ӵ�Ҳ��һ������������Ҫ�л����źͷֺ�
        ArtVideo.transform.DOScale(videoOriginScale, 1.0f).SetEase(Ease.InQuint).onComplete += () => { ArtVideo.Play(); }; //������Ƶ�������Ķ�̬���󽥱�
        ArtVideo.started += source => { ArtVideo.GetComponent<MeshRenderer>().material.DOColor(Color.white, 2f); }; //�������ſ����󣬽���ɫ��Ϊ��ɫ
        ButtonManager.buttonIcon = StopIcon;    //�л���ť״̬ͼ��
        ButtonManager.UpdateUI();
    }

    private void StopVideo()
    {
        Tweener _tweenerColor = ArtVideo.GetComponent<MeshRenderer>().material.DOColor(Color.black, 1.0f);  //��Ƶ�����𽥱��
        Tweener _tweenerScale = ArtVideo.transform.DOScaleX(0, 1.0f).SetEase(Ease.InQuint);
        _tweenerScale.onComplete += () => { ArtVideo.gameObject.SetActive(false); ArtVideo.Stop(); };   //��Ƶ���滺��Ϊ0��ֻת��
        Sequence _seq = DOTween.Sequence(); //�������У�����������������
        _seq.Append(_tweenerColor);
        _seq.Append(_tweenerColor);
        ButtonManager.buttonIcon = PlayIcon;
        ButtonManager.UpdateUI();
    }
}
