using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    static bool AudioBegin = false;
    AudioSource my_audio;

    void Awake() {
        if (!AudioBegin) {
            my_audio = gameObject.GetComponent<AudioSource>();
            my_audio.volume = 0.5f;
            my_audio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        //if (Input.GetButtonDown("Mute")) {
        //    if (my_audio.volume != 0) {
        //        my_audio.volume = 0;
        //    } else {
        //        my_audio.volume = 1;
        //    }
        //}
    }

}
