using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBBSaveValue : MonoBehaviour
{
    public string Intro1;
    public string Intro2;

    public Sprite IntroImage;

    public static BBBManager Manager;

    private void Awake()
    {
        Manager = FindObjectOfType<BBBManager>();
    }

    public void ConveyValue()
    {
        Manager.ShowIntroUI(Intro1,Intro2,IntroImage);
    }
}
