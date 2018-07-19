using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -6.0f)
        {
            SetMikuDied();
        }
    }
    
    void SetMikuDied()
    {
        DestroyObject(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
