using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class shaker : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin perl;
    private void Start()
    {
        perl = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
           perl.m_AmplitudeGain = 0.4f; 
        }
        else 
        {
            perl.m_AmplitudeGain = 0f;
        }
    }
}
