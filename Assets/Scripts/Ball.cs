﻿using System;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isFireball;
    public float fireballDuration;

    public float scale = .7f;
    public ParticleSystem fireBallEffectCore;
    public SpriteRenderer sr;

    public static event Action<Ball> OnFireBallEnable;
    public static event Action<Ball> OnFireBallDisable;

    public void StartFireBall()
    {
        if (!this.isFireball)
        {
            this.isFireball = true;
            this.sr.enabled = false;
            fireBallEffectCore.gameObject.SetActive(true);
            StartCoroutine(StopFireBallAfterTime(this.fireballDuration));

            OnFireBallEnable?.Invoke(this);
        }
    }

    public void StopFireball()
    {
        if (this.isFireball)
        {
            this.isFireball = false;
            this.sr.enabled = true;
            fireBallEffectCore.gameObject.SetActive(false);

            OnFireBallDisable?.Invoke(this);
        }
    }

    private IEnumerator StopFireBallAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        StopFireball();
    }
}