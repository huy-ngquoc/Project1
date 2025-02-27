#nullable enable

namespace Game;

public sealed partial class SkeletonStateMachine : EnemyStateMachine
{
    public SkeletonStateMachine()
    {
        this.SkeletonIdleState = new SkeletonIdleState(this, "Idle");

        this.SetStateToChangeTo(this.SkeletonIdleState);
    }

    public SkeletonController? SkeletonController => this.EnemyController as SkeletonController;

    public SkeletonIdleState SkeletonIdleState { get; }
}
