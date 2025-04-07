using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)  //寻找另一个碰撞机，此处命名为other
    {
        if (other.tag == "Player")  //用tag系统来辨别什么时候应该“Hit”，否则碰到地面也算减血
        {
            //Debug.Log("Hit");  只是用于调试，打印在console
            //FindObjectOfType<PlayerHealthController>().DealDamage();  还是过于繁琐
            PlayerHealthController.instance.DealDamage();
        }

    }
}
