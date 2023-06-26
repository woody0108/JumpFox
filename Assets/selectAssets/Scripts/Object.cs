using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //protected virtual


    protected float speed = 3f;
    protected float delay = 5f;
    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


    }


    protected IEnumerator SetCoinCoroutine()
    {
        yield return new WaitForSeconds(delay);
        ObjectPoolingManager.Instance.Set(gameObject, EObjectFlag.coin);
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(SetCoinCoroutine());
    }

   

}
