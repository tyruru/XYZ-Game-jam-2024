using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Walk walk;
    private Animator animator;
    private IsGost isGost;


    void Start()
    {
        walk = GetComponent<Walk>();
        animator = GetComponent<Animator>();
        isGost = GetComponent<IsGost>();

    }

    private void Update()
    {
        ChangedAnimationState(0);
        //walk
        if (walk.IsWalk)
            ChangedAnimationState(1);
        //Gost
        if (isGost.Gost)
            ChangedAnimationState(2);
    }

    void ChangedAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }
}
