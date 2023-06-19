using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 3f * Time.deltaTime);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObjectPoolingManager.Instance.Set(this.gameObject, EObjectFlag.coin);

        }
    }

}
