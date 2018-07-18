using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_control : MonoBehaviour {

    public AnimationCurve curve;

    public GameObject SpawnPrefab;
    public GameObject nextPrefab;

    IEnumerator sample()
    {
        Vector2 pos = transform.position;

        for(float t=0;t<curve.keys[curve.length-1].time;t+=Time.deltaTime)
        {
            transform.position = new Vector2(pos.x, pos.y + curve.Evaluate(t));

            yield return null;
        }

        //金币
        if(SpawnPrefab)
        {
            Instantiate(SpawnPrefab, transform.position + Vector3.up, Quaternion.identity);
        }

        if(nextPrefab)
        {
            Instantiate(nextPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].point.y<transform.position.y)
        {
            StartCoroutine("sample");
        }
    }
}
