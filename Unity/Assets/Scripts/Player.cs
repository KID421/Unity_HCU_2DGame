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

    public Transform point;

    private Animator ani;
    private Rigidbody2D r2d;
    private AudioSource aud;
    #endregion

    private void Start()
    {
        ani = GetComponent<Animator>();         // 動畫元件 = 取得元件<動畫元件>()
        r2d = GetComponent<Rigidbody2D>();      // 剛體元件 = 取得元件<剛體元件>()
        aud = GetComponent<AudioSource>();      // 音源元件 = 取得元件<音源元件>()
    }

    // 一秒執行 50 次
    private void FixedUpdate()
    {
        Move();
    }
    // 一秒執行 60 次
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(soundFire);
            Instantiate(bullte, point.position, Quaternion.identity);
        }
    }
}
