using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartDoorTrigger : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float triggerDistance = 3f;

    private bool isOpen = false;
    private bool openedInward = false;

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= triggerDistance && !isOpen)
        {
            Vector3 toPlayer = player.position - transform.position;
            float dot = Vector3.Dot(transform.forward, toPlayer.normalized);

            if (dot > 0)
            {
                animator.SetTrigger("OpenOut");
                openedInward = false;
            }
            else
            {
                animator.SetTrigger("OpenIn");
                openedInward = true;
            }

            isOpen = true;
        }

        if (distance > triggerDistance + 1f && isOpen)
        {
            if (openedInward)
                animator.SetTrigger("CloseIn");
            else
                animator.SetTrigger("CloseOut");

            isOpen = false;
        }
    }
}

