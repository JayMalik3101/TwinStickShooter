using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    public AnimationState m_AnimationState;

    public void SetAnimation(AnimationState animatestation)
    {
        m_AnimationState = animatestation;
    }
}
