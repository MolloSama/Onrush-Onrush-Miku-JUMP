using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DestroyCloud());
    }

    IEnumerator DestroyCloud()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
