﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDresserController : MonoBehaviour
{
    private Animator dresserAnim;
    private bool dresserOpen = false;

    public AudioSource audio;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "BottomDresserOpen1";
    [SerializeField] private string closeAnimationName = "BottomDresserClose";

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        dresserAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void PlayAnimation()
    {
        if (!dresserOpen && !pauseInteraction)
        {
            audio.Play();
            dresserAnim.Play(openAnimationName, 0, 0.0f);
            dresserOpen = true;
            StartCoroutine(PauseDoorInteraction());
        }

        else if (dresserOpen && !pauseInteraction)
        {
            audio.Play();
            dresserAnim.Play(closeAnimationName, 0, 0.0f);
            dresserOpen = false;
            StartCoroutine(PauseDoorInteraction());
        }
    }
}
