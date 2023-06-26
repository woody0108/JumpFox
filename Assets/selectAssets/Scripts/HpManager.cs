using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class HpManager : MonoBehaviour
{
    #region 싱글톤
    private static HpManager instance;
    public static HpManager Instance
    {
        get { return instance; }
    }
    #endregion

    public float dampening = 5f;
    public float changeSpeed = 0.5f;
    private Player player;
    float timeout = 0f;

    Material mat;
    float fillTarget = 1f;
    float delta = 0f;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;


        }
        else
        {
            Destroy(this.gameObject);
        }
        player = Player.Instance;
        Renderer rend = GetComponent<Renderer>();
        Image img = GetComponent<Image>();
        if (rend != null)
        {
            mat = new Material(rend.material);
            rend.material = mat;
        }
        else if (img != null)
        {
            mat = new Material(img.material);
            img.material = mat;
        }
        else
        {
            Debug.LogWarning("No Renderer or Image attached to " + name);
        }
    }

    void Update()
    {
        timeout += Time.deltaTime * changeSpeed;
        if (timeout > 0.5f)
        {
            timeout = 0f;

            player.health -= 1; // 각 0.5초마다 체력 감소
            if (player.health < 0)
                player.health = 0;
            UpdateFillTarget();
        }

        delta = Mathf.Lerp(delta, 0, Time.deltaTime * dampening);
        mat.SetFloat("_Delta", delta);
        mat.SetFloat("_Fill", fillTarget);
    }

    public void UpdateFillTarget()
    {
        float targetFillValue = (float)player.health / player.maxHealth;
        delta -= fillTarget - targetFillValue;
        fillTarget = targetFillValue;
    }
}