using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleHealthBar : MonoBehaviour {
    [SerializeField] private Image m_Bar;
    //public RectTransform m_Button; red knob 


    public float m_HealthValue = 0;
    
	void Update () {
        HealthChange(m_HealthValue);
	}

    private void HealthChange(float healthvalue)
    {
        float amount = (healthvalue / 100.0f) * 180.0f / 360;
        m_Bar.fillAmount = amount;
        /*
        float buttonAngle = amount * 360;
        m_Button.localEulerAngles = new Vector3(0, 0, -buttonAngle);
        */
    }
}
