
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // 플레이어의 Transform을 받아올 변수
    public Vector3 offset;   // 카메라와 플레이어 사이의 거리를 조절하기 위한 오프셋 값
    public float fixedY;     // 고정할 y 값

    private void LateUpdate()
    {
        if (target != null)
        {
            // 플레이어의 위치에서 x, fixedY, z 값을 더한 값을 카메라 위치로 설정
            transform.position = new Vector3(target.position.x + offset.x, fixedY, target.position.z + offset.z);
        }
    }
}






