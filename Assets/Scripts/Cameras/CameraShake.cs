using Unity.Cinemachine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CameraShake : MonoBehaviour
{

    private CinemachineCamera myVirtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    public static CameraShake instance;

    private void Awake()
    {
        instance = this;

        myVirtualCamera = GetComponent<CinemachineCamera>();
        noise = myVirtualCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();

        noise.AmplitudeGain = 0f;
        
    }

    public void ShakeCamera(float intensity, float shakingTime)
    {
        noise.AmplitudeGain = intensity;
        StartCoroutine(StopShaking(shakingTime));
    }

    IEnumerator StopShaking(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        noise.AmplitudeGain = 0f;
    }
    
}
