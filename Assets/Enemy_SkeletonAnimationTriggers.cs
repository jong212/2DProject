using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonAnimationTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy_Skeleton enemy => GetComponentInParent<Enemy_Skeleton>();

  private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
}
