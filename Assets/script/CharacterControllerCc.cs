using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterControllerCc : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // 移動速度
    [SerializeField] float gravityScale = 1f; //　重力
    [SerializeField] float jumpSpeed = 10f;// ジャンプ力
    [SerializeField] float turnSpeed = 10f;// キャラクターの回転速度
    
    float x;//x軸
    float z;//z軸 
    string clipName;//再生中のanimation名
    CharacterController cc;
    Animator m_anim;
    AnimatorClipInfo[] stateInfo;
    Vector3 velocity = Vector3.zero;//移動量
    Vector3 dir = Vector3.zero;//移動方向

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        m_anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationClip();

        //入力された方向を取得する
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        //入力方向のベクトルを取得する
        dir = new Vector3(x, 0f, z);

        //カメラを基準に入力方向にキャラクターを向ける
        dir = Camera.main.transform.TransformDirection(dir);
        //transform.Rotate(0, dir, 0);
        //入力方向に回転させる
        Quaternion targetRotation = Quaternion.LookRotation(dir);

        if (dir != Vector3.zero)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
        //this.transform.rotation.x = 0f;

        velocity = new Vector3(dir.x, velocity.y, dir.z);
        //重力を加える
        velocity += Physics.gravity * gravityScale * Time.deltaTime;
        var moveDir = new Vector3(velocity.x * moveSpeed, velocity.y, velocity.z * moveSpeed);
        if (clipName != "Attack1")
        cc.Move(moveDir * Time.deltaTime);
        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpSpeed;
            m_anim.SetTrigger("Jump");
        }
        if (Input.GetButtonDown("Attack") && cc.isGrounded)
        {
            Attack();
        }
        if (Input.GetButtonDown("Slide") && cc.isGrounded && clipName == "Run")
        {
            Slide();
        }
    }

    void LateUpdate()
    {
        Vector3 horizontalVelocity = velocity;
        horizontalVelocity.y = 0;
        m_anim.SetFloat("Speed", horizontalVelocity.magnitude);
        
    }

    /// <summary>
    /// 攻撃する
    /// </summary>
    void Attack()
    {
        m_anim.SetTrigger("Attack");
    }

    /// <summary>
    /// スライディングさせる
    /// </summary>
    void Slide()
    {
        m_anim.SetTrigger("Slide");
        if (clipName == "Slide")
        {
            velocity.x *= 10f;
            velocity.z *= 10f;
        }
    }
    /// <summary>
    /// 再生中のanimation名を取得
    /// </summary>
    void AnimationClip()
    {
        //再生中のanimation名を取得する
        stateInfo = m_anim.GetCurrentAnimatorClipInfo(0);
        clipName = stateInfo[0].clip.name;
    }

    
}
