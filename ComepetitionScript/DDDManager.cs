using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DDDManager : MonoBehaviour
{
    public string SaveText;
    public Text IntroText;

    public Coroutine FadeOut;
    public Coroutine Keyboard;

    public Coroutine FadeOut1;
    public Coroutine Keyboard1;

    public Coroutine FadeOut2;
    public Coroutine Keyboard2;

    public CanvasGroup MyCanvasGroup;

    public GameObject IntroUI;
    // Start is called before the first frame update
    void Start()
    {
        SaveText = IntroText.text;
        IntroText.text = "";
        FadeOut = StartCoroutine(UIFadeOut());
        Keyboard = StartCoroutine(UIKeyboard());
    }

    IEnumerator UIFadeOut()
    {
        MyCanvasGroup.alpha = 0f;

        while(MyCanvasGroup.alpha < 1f)
        {
            MyCanvasGroup.alpha += 0.02f;
            yield return new WaitForSeconds(0.1f);
        }

        MyCanvasGroup.alpha = 1f;
    }

    IEnumerator UIKeyboard()
    {
        for(int i = 1; i < SaveText.Length; i++)
        {
            IntroText.text = SaveText.Substring(0,i - 1) + "<color=#1234ffff>" + SaveText.Substring(i - 1, 1) + "</color>";
            yield return new WaitForSeconds(0.08f);
        }
        IntroText.text = SaveText;
    }

    public void ToFirst()
    {
        StopAllCoroutines();
        SaveText = "������:ǧ��ǧ�۹����������»���ʮ�˲��ڣ���Ϊ�������༪����Ů�������죬�ֳƹ����죬˾���Ұ�̩�����˸��£�����Ů֮�Σ���Ϊ��ɳ������֮�û��������ڹ�ӡ��ԭΪ���˲Ƹ�������Ů��ͼ����Ůͷ������ڣ��ν��������Ƽ�������ȹ�࣬һ���û���һ����������ʩ��״��������������ֹ��ׯ�����μ�������������ʵ�е��ϲ����Ů�ӡ�";
        IntroText.text = "";
        IntroUI.SetActive(true);
        FadeOut1 = StartCoroutine(UIFadeOut());
        Keyboard1 = StartCoroutine(UIKeyboard());
    }

    public void ToSecond()
    {
        StopAllCoroutines();
        SaveText = "����:ͷ��������˫���ٴ���������,���Ӻ��������,������Ʈ������������������������Ϲ������������Դ�ͯ�ɵ����棬��ȹ��īɫ��Ⱦ��Ũ�ܵĲ���Ϳ��ɫ,����ɫ��Ʈ���γɶԱȣ�ɫ�ʻ��Э����";
        IntroText.text = "";
        IntroUI.SetActive(true);
        FadeOut1 = StartCoroutine(UIFadeOut());
        Keyboard1 = StartCoroutine(UIKeyboard());
    }

    public void CloseIntroUI()
    {
       IntroUI.SetActive(false);
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene("EEE");
    }
}
