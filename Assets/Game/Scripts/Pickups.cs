﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {
    // use this as base for inheritence for all pickups
    // put item bobbing and rotating when in worldspace here. Put pickup on e here.
    private Transform m_ItemTransform;
    private bool goUp = true;
    private float changeNumber = 0.1f;
    private void Start()
    {
        m_ItemTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        ItemRotation();
        ItemBobbing();
    }

    private void ItemRotation()
    {
        m_ItemTransform.Rotate( new Vector3(Vector3.up.x, Vector3.up.y + 20, Vector3.up.z)  *  Time.deltaTime );
        this.transform.rotation = m_ItemTransform.rotation;
    }

    private void ItemBobbing()
    {
        
        if(m_ItemTransform.position.y >= 1) {
            changeNumber *= -1;
            m_ItemTransform.position = (new Vector3(m_ItemTransform.position.x, 0.99f, m_ItemTransform.position.z));
        }
        else if(m_ItemTransform.position.y <= 0.431)
        {
            changeNumber *= -1;
            m_ItemTransform.position = (new Vector3(m_ItemTransform.position.x, 0.44f, m_ItemTransform.position.z));
        }

        m_ItemTransform.position = (new Vector3(m_ItemTransform.position.x, m_ItemTransform.position.y + changeNumber * Time.deltaTime, m_ItemTransform.position.z));
        this.transform.position = m_ItemTransform.position;
    }

}
