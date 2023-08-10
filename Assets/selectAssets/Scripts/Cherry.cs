using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Object
{
    private void Start()
    {
        flag = 0;
    }





    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.health += 5;
            HpManager.Instance.UpdateFillTarget();
            ObjectPoolingManager.Instance.Set(this.gameObject, EObjectFlag.cherry);

        }
    }

}
