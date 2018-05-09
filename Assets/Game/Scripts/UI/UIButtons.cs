using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{

    public void Iwanttodie()
    {
        Application.Quit();
        Debug.Log("I want to die)");
    }
}
