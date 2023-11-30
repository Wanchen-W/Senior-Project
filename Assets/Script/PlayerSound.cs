using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip walk, attack, death, jump, dash, tookDamage, healthUp, energyUp;
    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
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

    public void playJump() {
        audio.PlayOneShot(jump);
    }

    public void playDash() {
        audio.PlayOneShot(dash);
    }

    public void playTookDamage() {
        audio.PlayOneShot(tookDamage);
    }

    public void playHealthUp() {
        audio.PlayOneShot(healthUp);
    }

    public void playEnergyUp() {
        audio.PlayOneShot(energyUp);
    }
}
