using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource fall;
    public AudioSource walk;
    public AudioSource deathSound;
    public AudioSource winSound;

    bool _flagFallSound = false;

    private void OnEnable()
    {
        Jump.OnJumped += JumpSound;
        CollisionState.OnLanded += FallSound;
        Walk.OnWalk += WalkSound;
        DeathMenu.OnDeath += DeathSound;
        WinPoint.OnWin += WinSound;
    }

    private void OnDisable()
    {
        Jump.OnJumped -= JumpSound;
        CollisionState.OnLanded -= FallSound;
        Walk.OnWalk -= WalkSound;
        DeathMenu.OnDeath -= DeathSound;
        WinPoint.OnWin -= WinSound;
    }

    public void JumpSound()
    {
        jump.Play();
    }

    public void FallSound()
    {
        if (_flagFallSound == false)
        {
            fall.Play();
            _flagFallSound = true;
            StartCoroutine(Timer());
            _flagFallSound = false;
        }
    }

    public void WalkSound()
    {
        walk.Play();
    }

    public void DeathSound()
    {
        deathSound.Play();
    }

    public void WinSound()
    {
        winSound.Play();
    }

    private IEnumerator Timer()
    {
        // Ждем нужное количество времени
        yield return new WaitForSecondsRealtime(0.5f);

    }
}
