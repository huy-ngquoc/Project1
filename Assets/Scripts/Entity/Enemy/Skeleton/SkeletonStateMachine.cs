#nullable enable

namespace Game;

public sealed partial class SkeletonStateMachine : EnemyStateMachine
{
    public SkeletonStateMachine(SkeletonController skeletonController)
        : base(skeletonController)
    {
        this.SkeletonController = skeletonController;
        this.SkeletonIdleState = new SkeletonIdleState(this, "Idle");

        this.ChangeState(this.SkeletonIdleState);
    }

    public SkeletonController SkeletonController { get; }

    public SkeletonIdleState SkeletonIdleState { get; }
}
