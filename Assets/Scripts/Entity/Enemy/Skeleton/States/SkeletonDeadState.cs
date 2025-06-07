#nullable enable

namespace Game;

using UnityEngine;

public sealed class SkeletonDeadState : SkeletonState
{
    public SkeletonDeadState(SkeletonGeneralStateMachine skeletonGeneralStateMachine)
    {
        this.SkeletonGeneralStateMachine = skeletonGeneralStateMachine;
    }

    public override SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    public override string AnimationBoolName { get; } = AnimationNameConstants.Bool.Idle;

    protected override void OnSkeletonStateEnter()
    {
        this.SkeletonController.Animator.SetBool(this.SkeletonGeneralStateMachine.LastAnimationBoolName, true);
        this.SkeletonController.Animator.speed = 0;
        this.SkeletonController.CapsuleCollider2D.enabled = false;
        this.StateTimer = 0.15F;
    }

    protected override void OnSkeletonStateUpdate()
    {
        if (this.StateTimer > 0)
        {
            this.SkeletonController.Rigidbody2D.linearVelocity = new Vector2(0, 10);
        }
        else
        {
            Object.Destroy(this.SkeletonController.gameObject);
        }
    }
}
