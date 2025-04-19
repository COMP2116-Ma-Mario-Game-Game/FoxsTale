using System.Collections; //任何计算机都会使用的基本元素，如数字字母字符串
using System.Collections.Generic;
using UnityEngine; //Unity引擎，允许我们使用Unity某些内置元素（physics/colliders/transform）

public class PlayerController : MonoBehaviour //MonoBehaviour是一个普通脚本
{
    public static PlayerController instance;
    public float moveSpeed; //pubic/private显示他是否可以在编译器中被看到
    public Rigidbody2D theRB; //控制角色物理的组件 刚体
    public float jumpForce;

    private bool isGrounded; //判断是否在地面上(ground),默认为false
    public Transform groundCheckPoint; //用来禁止空中无限跳跃
    public LayerMask whatIsGround;

    private bool canDoubleJump; //双跳

    private Animator anim; //动画控制
    private SpriteRenderer theSR; //左右翻转

    public float knockbackLength, knockbackForce;
    private float knockbackCounter;  //跟踪

    public bool stopInput;

    public float bounceForce;

    private void Awake() //在start()之前运行
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //游戏开始立即运行
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() //frames 视觉发生，角色移动，每秒发生的改变
    {
        if (!PauseMenu.instance.isPaused && !stopInput)
        {
            if (knockbackCounter <= 0)
            {
                theRB.linearVelocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.linearVelocity.y); //GetAxisRaw获取-1到1的值(用户直接输入)，而GetAxis在ProjectSettings里面的InputManager内是设置为3的，所以看起来滑溜溜的。而我不想要这种质感。

                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

                if (isGrounded) //如果现在在地面上，则下一次跳跃应该被允许双跳
                {
                    canDoubleJump = true;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                        theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(10);
                    }

                    else //如果此刻在空中
                    {
                        if (canDoubleJump) //在空中且在上一阶段（没有经历过双跳/没被设为false）
                        {
                            theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                            canDoubleJump = false;
                            AudioManager.instance.PlaySFX(10);
                        }
                    }
                }

                if (theRB.linearVelocity.x < 0)
                {
                    theSR.flipX = true; //左移
                }
                else if (theRB.linearVelocity.x > 0) //这里是右移，但如果x=0的话还是默认为刚刚那个状态
                {
                    theSR.flipX = false;
                }
            }
            else
            {
                knockbackCounter -= Time.deltaTime;
                //theRB.velocity = new Vector2(0f, 0f);
                if (!theSR.flipX)
                {
                    theRB.linearVelocity = new Vector2(-knockbackForce, theRB.linearVelocity.y);
                }
                else
                {
                    theRB.linearVelocity = new Vector2(-knockbackForce, theRB.linearVelocity.y);
                }
            }
        }
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.linearVelocity.x)); //这里要设计绝对值，因为左移是负数体现

    }

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        theRB.linearVelocity = new Vector2(0f, knockbackForce);

        anim.SetTrigger("hurt");
    }

    public void Bounce()
    {
        theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, bounceForce);
        AudioManager.instance.PlaySFX(10);
    }
}
