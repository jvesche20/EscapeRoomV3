﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour
{
    private Animator dresserAnim;
    private bool dresserOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "pictureFall";
    

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
            dresserAnim.Play(openAnimationName, 0, 0.0f);
            dresserOpen = true;
            StartCoroutine(PauseDoorInteraction());
        }

        
    }
}
