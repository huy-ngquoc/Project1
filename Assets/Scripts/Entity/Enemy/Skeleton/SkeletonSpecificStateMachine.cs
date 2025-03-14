#nullable enable

namespace Game;

public abstract class SkeletonSpecificStateMachine : EnemySpecificStateMachine
{
    public abstract SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    public sealed override EnemyGeneralStateMachine EnemyGeneralStateMachine => this.SkeletonGeneralStateMachine;

    public SkeletonController SkeletonController => this.SkeletonGeneralStateMachine.SkeletonController;
}
