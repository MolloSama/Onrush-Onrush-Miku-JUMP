using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miku_control : MonoBehaviour {

	private float speed = 5f;       //移动速度因子
    [Range(0, 1)]
    private float slidefactor = 0.9f;      //滑动速度因子

    private float jumpfactor = 15f;    //向上跳动的力

    bool isGround()
    {
        //获取边界以及范围:高度的10%
        Bounds bounds = GetComponent<Collider2D>().bounds;
        float range = bounds.size.y * 0.1f;

        //计算碰撞下方的位置
        Vector2 v = new Vector2(bounds.center.x, bounds.min.y - range);

        //发射一条射线
        RaycastHit2D hit = Physics2D.Linecast(v, bounds.center);

        return (hit.collider.gameObject != gameObject);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if(h!=0)
        {
            //向左还是向右
            GetComponent<Rigidbody2D>().velocity = new Vector2(h * speed,v.y);
            transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * slidefactor, v.y);
        }

        GetComponent<Animator>().SetFloat("speed", Mathf.Abs(h));

        bool grounded = isGround();
        if(Input.GetKeyDown(KeyCode.UpArrow)&&grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpfactor;
            GetComponent<AudioSource>().Play();
        }
        GetComponent<Animator>().SetBool("isjump", !grounded);

    }


}
