
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // �÷��̾��� Transform�� �޾ƿ� ����
    public Vector3 offset;   // ī�޶�� �÷��̾� ������ �Ÿ��� �����ϱ� ���� ������ ��
    public float fixedY;     // ������ y ��

    private void LateUpdate()
    {
        if (target != null)
        {
            // �÷��̾��� ��ġ���� x, fixedY, z ���� ���� ���� ī�޶� ��ġ�� ����
            transform.position = new Vector3(target.position.x + offset.x, fixedY, target.position.z + offset.z);
        }
    }
}






