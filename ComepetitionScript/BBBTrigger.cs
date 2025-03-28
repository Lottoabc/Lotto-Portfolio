using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBBTrigger : MonoBehaviour
{
    public GameObject SloganUI;

    // Start is called before the first frame update
    void Start()
    {
        SloganUI.SetActive(false);    
    }

    private void OnTriggerEnter(Collider other)
    {
        SloganUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        SloganUI.SetActive(false);
    }
}
