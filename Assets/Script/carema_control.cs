using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carema_control : MonoBehaviour {

    public GameObject miku;
    private Transform mikuTransform;

    // Use this for initialization
    void Start()
    {
        miku = GameObject.FindGameObjectWithTag("miku");
        mikuTransform = miku.transform;
    }

    // Update is called once per frame
    void Update()
    {

        //相机不能回退

    }

    void LateUpdate()
    {
        if (mikuTransform != null)
        {
            //相机向右
            if (mikuTransform.position.x - 0.5f > transform.position.x)
            {
                Camera.main.transform.position = new Vector3(mikuTransform.position.x - 0.5f, transform.position.y, transform.position.z);
            }

            //相机向左
            if (mikuTransform.position.x + 0.5f < transform.position.x)
            {
                Camera.main.transform.position = new Vector3(mikuTransform.position.x + 0.5f, transform.position.y, transform.position.z);
            }
        }

	}
}
