using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{

    public void Iwanttodie()
    {
        Application.Quit();
        Debug.Log("I want to die)");
    }
    public void IwanttobeBIG()
    {
        Screen.fullScreen = true;
        Debug.Log("BIG TIME");
    }
    public void SceneSwitching(int DesiredScene)
    {
        SceneManager.LoadScene(DesiredScene);
    }
}
