using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_control : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
}
