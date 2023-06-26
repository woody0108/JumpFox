using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Object
{
    // Update is called once per frame
   

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.health += 5;
            HpManager.Instance.UpdateFillTarget();
            ObjectPoolingManager.Instance.Set(this.gameObject, EObjectFlag.cherry);

        }
    }

}
