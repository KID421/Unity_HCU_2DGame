﻿using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 2000)]
    public float speed = 1.5f;
    [Header("血量"), Range(100, 1000)]
    public float hp = 100;

    private Animator ani;
    private Rigidbody2D r2d;
    #endregion

    private void Start()
    {
        ani = GetComponent<Animator>();
        r2d = GetComponent<Rigidbody2D>();
    }
}
