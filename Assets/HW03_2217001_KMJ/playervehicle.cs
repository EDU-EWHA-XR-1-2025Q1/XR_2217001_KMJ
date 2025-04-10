using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playervehicle : MonoBehaviour
{
    public Animator anim;

    private bool goingToRoom2 = true;
    private bool isAnimating = false;
    private bool hasArrived = false;

    private float lastPlaybackTime = 0f;
    private string currentAnimName = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            other.transform.position = transform.position + Vector3.up * 2f;

            if (anim != null)
            {
                anim.speed = 1f;

                if (!isAnimating)
                {
                    if (goingToRoom2)
                    {
                        anim.SetTrigger("ToRoom2");
                        currentAnimName = "DriveToRoom2";
                    }
                    else
                    {
                        anim.SetTrigger("ToRoom1");
                        currentAnimName = "DriveToRoom1";
                    }

                    isAnimating = true;
                    hasArrived = false;
                    lastPlaybackTime = 0f;
                }
                else
                {
                    // 중간 하차 후 재탑승 -> 이어서 재생하게....
                    anim.Play(currentAnimName, 0, lastPlaybackTime);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);

            if (anim != null && isAnimating)
            {
                AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
                lastPlaybackTime = info.normalizedTime % 1f;

                anim.speed = 0f;
            }
        }
    }

    private void Update()
    {
        if (anim != null && isAnimating && !hasArrived)
        {
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

           
            if (info.IsName(currentAnimName) && info.normalizedTime >= 0.99f)
            {
                
                goingToRoom2 = !goingToRoom2;
                isAnimating = false;
                hasArrived = true;
                lastPlaybackTime = 0f;
                currentAnimName = "";
            }
        }
    }
}
