using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
    public void White()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
