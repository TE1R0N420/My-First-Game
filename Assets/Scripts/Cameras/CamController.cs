using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class CamController : MonoBehaviour
{

    PlayerController playerToLookAt;
    CinemachineCamera virtualCamera;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerToLookAt = FindFirstObjectByType<PlayerController>();
        virtualCamera = GetComponent<CinemachineCamera>();

        virtualCamera.Follow = playerToLookAt.transform;
    }

    // Update is called once per frame
    void Update()
    {
        while(playerToLookAt == null)
        {
            playerToLookAt = FindFirstObjectByType<PlayerController>();

            if (virtualCamera)
            {
                virtualCamera.Follow = playerToLookAt.transform;
            }
        }
    }
}
