using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {
    private GameObject chime_sound;
    private bool sound_played;

    private void Awake() {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);
    }

    void Start() {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        chime_sound = GameObject.Find("Splash Chime");
        sound_played = false;
    }

    void Update() {
        if( gameObject.transform.localScale != new Vector3(1,1,0) ) {
            gameObject.transform.localScale += new Vector3(0.01F, 0.01f, 0);
        } else {
            if( !sound_played ) {
                sound_played = true;
                chime_sound.GetComponent<AudioSource>().volume = 0.5f;
                chime_sound.GetComponent<AudioSource>().Play();
                Invoke("GotoTitle", 2f);
            }
        }
    }

    void GotoTitle() {
        SceneManager.LoadScene("MainMenu");
    }
}
