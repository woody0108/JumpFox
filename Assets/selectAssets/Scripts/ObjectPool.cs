using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    public GameObject copyObj;      // ������ ������
    public GameObject parent;   // ������ ������Ʈ�� �θ�
    public int initCount;       // ó���� �� �� ��������
    public Queue<GameObject> queue = new Queue<GameObject>();   // ������Ʈ���� ���� ť
}
