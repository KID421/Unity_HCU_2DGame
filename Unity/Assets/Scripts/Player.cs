using UnityEngine;

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
        ani = GetComponent<Animator>();         // 動畫元件 = 取得元件<動畫元件>()
        r2d = GetComponent<Rigidbody2D>();      // 剛體元件 = 取得元件<剛體元件>()
    }

    // 一秒執行 50 次
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");   // 左 A -1、右 D 1、沒按 0
        r2d.AddForce(new Vector2(speed * h, 0));    // 剛體.推力(二為向量(左右，上下))
    }
}
