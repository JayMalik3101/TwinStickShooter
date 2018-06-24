using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {
    public bool m_IsDead;
    public AnimationState m_AnimationState;
    private Animator m_Animator;

    public void SetAnimation(AnimationState animatestation)
    {
        m_AnimationState = animatestation;
    }

    private void Update()
    {
        m_Animator.SetInteger("State", (int)m_AnimationState);
    }
}
