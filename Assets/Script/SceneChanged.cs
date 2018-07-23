using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanged : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene("Second Scene");
    }
}
