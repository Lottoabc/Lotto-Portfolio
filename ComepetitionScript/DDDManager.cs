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
        SaveText = "吉祥天:千手千眼观音左右上下画二十八部众，此为北壁西侧吉祥天女，吉祥天，又称功德天，司国家安泰及个人福德，作天女之形，传为武沙门天王之妹或王妃，在古印度原为命运财富和美的女神，图中天女头戴花议冠，饰巾帼，穿云肩羽袖大带裙襦，一手拿花，一手扬起似作施与状，形容秀丽，举止端庄，服饰及人物气质如现实中的上层社会女子。";
        IntroText.text = "";
        IntroUI.SetActive(true);
        FadeOut1 = StartCoroutine(UIFadeOut());
        Keyboard1 = StartCoroutine(UIKeyboard());
    }

    public void ToSecond()
    {
        StopAllCoroutines();
        SaveText = "飞天:头上簪花、双鬟髻垂于两耳旁,脸庞和身躯丰肥,宽阔的飘带绕体舒卷，手捧莲花作跪姿虔诚供养，深情中略带童稚的天真，长裙用墨色晕染，浓密的彩云涂黄色,与紫色的飘带形成对比，色彩浑厚协调。";
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
