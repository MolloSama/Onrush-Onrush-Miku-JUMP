using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudioControl : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(playAudio());
    }

    IEnumerator playAudio()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().enabled = false;
    }
}
