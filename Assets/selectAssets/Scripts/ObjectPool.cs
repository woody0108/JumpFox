using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    public GameObject copyObj;      // 복제할 프리팹
    public GameObject parent;   // 복제될 오브젝트의 부모
    public int initCount;       // 처음에 몇 번 복제할지
    public Queue<GameObject> queue = new Queue<GameObject>();   // 오브젝트들을 담을 큐
}
