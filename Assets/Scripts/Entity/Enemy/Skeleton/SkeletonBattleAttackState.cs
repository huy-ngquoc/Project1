#nullable enable

namespace Game;
public sealed class SkeletonBattleAttackState : SkeletonBattleState
{
    public SkeletonBattleAttackState(SkeletonBattleStateMachine skeletonBattleStateMachine)
    {
        this.SkeletonBattleStateMachine = skeletonBattleStateMachine;
    }

    public override SkeletonBattleStateMachine SkeletonBattleStateMachine { get; }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Attack;

    protected override void OnSkeletonBattleStateEnter()
    {
        this.SkeletonController.SetZeroLinearVelocityX();
    }

    protected override void OnSkeletonBattleStateUpdate()
    {
        if (this.TriggerCalled)
        {
            this.SkeletonBattleStateMachine.SetStateToChangeTo(this.SkeletonBattleStateMachine.IdleState);
        }
    }
}
