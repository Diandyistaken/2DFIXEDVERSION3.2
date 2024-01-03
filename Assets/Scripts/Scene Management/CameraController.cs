using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    public void SetPlayerCameraFollow()
    {
        cinemachineVirtualCamera = Object.FindFirstObjectByType<CinemachineVirtualCamera>();
        // veya
        // cinemachineVirtualCamera = Object.FindAnyObjectByType<CinemachineVirtualCamera>();

        if (cinemachineVirtualCamera != null)
        {
            cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
        }
        else
        {
            Debug.LogError("CinemachineVirtualCamera not found!");
        }
    }
}
