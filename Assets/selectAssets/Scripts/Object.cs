using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //protected virtual

   protected int flag = 0;

    protected float speed = 3f;
    protected float delay = 300f;
    // Update is called once per frame
    protected virtual void Update()
    {
        // transform.Translate(Vector2.left * speed * Time.deltaTime);


    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ResetPool"))
        {
            ObjectPoolingManager.Instance.Set(this.gameObject, (EObjectFlag)flag);

        }
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
