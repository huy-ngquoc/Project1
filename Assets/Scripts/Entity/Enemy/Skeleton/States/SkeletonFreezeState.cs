#nullable enable

namespace Game;

public sealed class SkeletonFreezeState : SkeletonState
{
    public SkeletonFreezeState(SkeletonGeneralStateMachine skeletonGeneralStateMachine)
    {
        this.SkeletonGeneralStateMachine = skeletonGeneralStateMachine;
    }

    public override SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    public override string AnimationBoolName => this.SkeletonGeneralStateMachine.LastAnimationBoolName;

    protected override void OnSkeletonStateEnter()
    {
        this.SkeletonController.Animator.speed = 0;
    }

    protected override void OnSkeletonStateExit()
    {
        this.SkeletonController.Animator.speed = 1;
    }
}
