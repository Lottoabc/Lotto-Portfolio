using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using UnityEngine.Video;
using DG.Tweening;

public class video_controller : MonoBehaviour
{
    public VideoPlayer ArtVideo;    //视屏播放器的引用
    private Vector3 videoOriginScale;   //视屏播放器的初始播放
    public Sprite PlayIcon; //使用素材包Play
    public Sprite StopIcon; //将使用素材包Cancel Bold
    public ButtonManagerIcon ButtonManager; //按钮管理器
    public AudioSource Museum_BGM;      //声明个变量用于管理BGM
    private bool isPlaying = false; //记录视频的播放状态

    // Start is called before the first frame update
    void Start()
    {
        videoOriginScale = ArtVideo.transform.localScale;   //获取视频对象原始播放
        ArtVideo.gameObject.SetActive(false);   //默认隐藏
        ArtVideo.Stop();    //默认视频不播放
    }

    public void OnButtonClick() //控制按钮点击处理函数
    {
        if (isPlaying)  //如果正在播放，将其关闭
        {
            Museum_BGM.UnPause();   //关闭bgm
            StopVideo();
            
        }
        else  //如果没有进行播放，将开始播放
        {
            Museum_BGM.Pause();     //开启bgm
            PlayVideo();
        }

        isPlaying = !isPlaying;
    }

    private void PlayVideo()
    {
        ArtVideo.gameObject.SetActive(true); //显示挂载了视频的游戏对象

        ArtVideo.transform.localScale = new Vector3(0f, videoOriginScale.y, videoOriginScale.z);    //让这个游戏对象从x轴向上从0到初始比例的缩放的缓动
        ArtVideo.GetComponent<MeshRenderer>().material.color = Color.black;
                                                                               //给onComplete这个事件当中指定一个匿名函数，添加的也是一个函数，所以要有花括号和分号
        ArtVideo.transform.DOScale(videoOriginScale, 1.0f).SetEase(Ease.InQuint).onComplete += () => { ArtVideo.Play(); }; //设置视频播放器的动态形象渐变
        ArtVideo.started += source => { ArtVideo.GetComponent<MeshRenderer>().material.DOColor(Color.white, 2f); }; //视屏播放开启后，将颜色调为白色
        ButtonManager.buttonIcon = StopIcon;    //切换按钮状态图标
        ButtonManager.UpdateUI();
    }

    private void StopVideo()
    {
        Tweener _tweenerColor = ArtVideo.GetComponent<MeshRenderer>().material.DOColor(Color.black, 1.0f);  //视频画面逐渐变黑
        Tweener _tweenerScale = ArtVideo.transform.DOScaleX(0, 1.0f).SetEase(Ease.InQuint);
        _tweenerScale.onComplete += () => { ArtVideo.gameObject.SetActive(false); ArtVideo.Stop(); };   //视频画面缓动为0，只转动
        Sequence _seq = DOTween.Sequence(); //创建队列，连续播放两个缓动
        _seq.Append(_tweenerColor);
        _seq.Append(_tweenerColor);
        ButtonManager.buttonIcon = PlayIcon;
        ButtonManager.UpdateUI();
    }
}
