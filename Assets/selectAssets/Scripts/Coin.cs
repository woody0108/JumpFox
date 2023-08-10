using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Object
{
    // Update is called once per frame

    private void Start()
    {
        flag = 0;
    }
   


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Coin++;
            ObjectPoolingManager.Instance.Set(this.gameObject, (EObjectFlag)flag);

        }
    }

}
