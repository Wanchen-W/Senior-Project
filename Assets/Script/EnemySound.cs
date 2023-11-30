using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour {
    public AudioClip walk, attack, death, tookDamage,
        idle1, idle2, idle3, idle4, idle5;
    AudioSource audio;
    float cd;

    void Start() {
        audio = GetComponent<AudioSource>();
        cd = 3.0f;
    }

    void Update() {
        cd -= Time.deltaTime;
        if(cd < 0) {
            if(Random.Range(0, 4) == 0) {
                int sound = Random.Range(0, 4);

                if(sound == 0) { audio.PlayOneShot(idle1); }
                else if(sound == 1) { audio.PlayOneShot(idle2); }
                else if(sound == 2) { audio.PlayOneShot(idle3); }
                else if(sound == 3) { audio.PlayOneShot(idle4); }
                else if(sound == 4) { audio.PlayOneShot(idle5); }
            }
            cd = 3.0f;
        }
    }

    public void playWalk() {
        audio.PlayOneShot(walk);
    }

    public void playAttack() {
        audio.PlayOneShot(attack);
    }

    public void playDeath() {
        audio.PlayOneShot(death);
    }

    public void playTookDamage() {
        audio.PlayOneShot(tookDamage);
    }
}
