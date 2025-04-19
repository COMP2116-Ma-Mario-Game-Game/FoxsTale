using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;  //无法改变
    public int currentHealth, maxHealth;  //用int而非float更省内存

    public float invincibleTime;  //收到打击后的无敌时间
    public float invincibleCounter;

    private SpriteRenderer theSR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject deathEffect;

    private void Awake()  //在start()之前运行
    {
        instance = this;  //指的是当前运行组件
    }
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);  //从透明恢复全彩
            }
        }

    }

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;

                //gameObject.SetActive(false);
                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleTime;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
                PlayerController.instance.Knockback();

                AudioManager.instance.PlaySFX(9);


            }
            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        currentHealth += 1;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
