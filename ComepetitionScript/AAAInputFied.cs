using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AAAInputFied : InputField
{
    // Start is called before the first frame update
    void Start()
    {
        keyboardType = (TouchScreenKeyboardType)(-1);
        base.Start();
    }

}
