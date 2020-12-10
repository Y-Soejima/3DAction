using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorControllerRb : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    [SerializeField] float movingSpeed = 5f;
    /// <summary>ターンの速さ</summary>
    [SerializeField] float turnSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    [SerializeField] float jumpPower = 5f;
    /// <summary>接地判定の際、中心 (Pivot) からどれくらいの距離を「接地している」と判定するかの長さ</summary>
    [SerializeField] float isGroundedLength = 1.1f;
    
    Animator anim = null;
    Rigidbody rb = null;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする

            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * turnSpeed);  // Slerp を使うのがポイント

            Vector3 velo = dir.normalized * movingSpeed; // 入力した方向に移動する
            velo.y = rb.velocity.y;   // ジャンプした時の y 軸方向の速度を保持する

            rb.velocity = velo;   // 計算した速度ベクトルをセットする
        }
        // ジャンプの入力を取得し、接地している時に押されていたらジャンプする
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        else
        {
            anim.ResetTrigger("Jump");
        }
        // 攻撃の入力を取得し、接地している時に押されていたら攻撃する
        if (Input.GetButtonDown("Attack") && IsGrounded())
        {
            Attack();
        }
        else
        {
            anim.ResetTrigger("Attack");
        }
        if (Input.GetButtonDown("Slide") && IsGrounded())
        {
            Slide();
        }
        else
        {
            anim.ResetTrigger("Slide");
        }
    }
    /// <summary>
    /// Update の後に呼び出される。Update の結果を元に何かをしたい時に使う。
    /// </summary>
    void LateUpdate()
    {
        // 水平方向の速度を求めて Animator Controller のパラメーターに渡す
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        anim.SetFloat("Speed", horizontalVelocity.magnitude);
    }
    /// <summary>
    /// 地面に接触しているか判定する
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        // Physics.Linecast() を使って足元から線を張り、そこに何かが衝突していたら true とする
        Vector3 start = this.transform.position;   // start: オブジェクトの中心
        Vector3 end = start + Vector3.down * isGroundedLength;  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする
        return isGrounded;
    }
    /// <summary>
    /// スライディングさせる
    /// </summary>
    void Slide()
    {
        anim.SetTrigger("Slide");
    }

    /// <summary>
    /// 攻撃する
    /// </summary>
    void Attack()
    {
        anim.SetTrigger("Attack");

    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        anim.SetTrigger("Jump");
    }

}
