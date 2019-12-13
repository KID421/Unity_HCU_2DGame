using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 2000)]
    public float speed = 1.5f;
    [Header("血量"), Range(100, 1000)]
    public float hp = 100;
    [Header("子彈物件")]
    public GameObject bullte;
    [Header("發射音效")]
    public AudioClip soundFire;
    [Header("子彈發射位置")]
    public Transform point;
    [Header("子彈速度"), Range(500, 3000)]
    public float speedBullet = 1000;

    private Animator ani;
    private Rigidbody2D r2d;
    private AudioSource aud;
    #endregion


    // 初始事件：遊戲開始執行一次
    private void Start()
    {
        ani = GetComponent<Animator>();         // 動畫元件 = 取得元件<動畫元件>()
        r2d = GetComponent<Rigidbody2D>();      // 剛體元件 = 取得元件<剛體元件>()
        aud = GetComponent<AudioSource>();      // 音源元件 = 取得元件<音源元件>()
    }
    // 固定更新事件：一秒執行 50 次
    private void FixedUpdate()
    {
        Move();
    }
    // 更新事件：一秒約執行 60 次
    private void Update()
    {
        Fire();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");                   // 左 A -1、右 D 1、沒按 0
        r2d.AddForce(new Vector2(speed * h, 0));                    // 剛體.推力(二為向量(左右，上下))
        if (h != 0) transform.localScale = new Vector3(h, 1, 1);    // 判斷水平不為 0 尺寸設為左 -1，右 1
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))                                                                   // 如果 按下 左鍵
        {
            aud.PlayOneShot(soundFire);                                                                         // 音源.播放一次音效(音效)
            GameObject temp = Instantiate(bullte, point.position, Quaternion.identity);                         // 暫存子彈 = 實例化(物件，座標，角度) - Quaternion.identity 零度角
            temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(speedBullet * transform.localScale.x, 80));   // 站存子彈.取得元件<剛體>().推力(玩家X * 速度)
        }
    }
}
