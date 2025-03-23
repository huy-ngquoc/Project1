#nullable enable

namespace Game;
public sealed class SkeletonBattleIdleState : SkeletonBattleState
{
    public SkeletonBattleIdleState(SkeletonBattleStateMachine skeletonBattleStateMachine)
    {
        this.SkeletonBattleStateMachine = skeletonBattleStateMachine;
    }

    public override SkeletonBattleStateMachine SkeletonBattleStateMachine { get; }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Idle;

    protected override void OnSkeletonBattleStateEnter()
    {
        this.StateTimer = this.SkeletonGeneralStateMachine.AttackCooldown;
    }

    protected override void OnSkeletonBattleStateUpdate()
    {
        if (this.StateTimer > 0)
        {
            return;
        }

        var playerRaycastHit2D = this.SkeletonController.IsPlayerDetected;
        if (!playerRaycastHit2D)
        {
            this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGeneralStateMachine.GroundedState);
            return;
        }

        if (playerRaycastHit2D.distance > this.SkeletonController.AttackRange)
        {
            this.SkeletonBattleStateMachine.SetStateToChangeTo(this.SkeletonBattleStateMachine.MoveState);
            return;
        }

        this.SkeletonBattleStateMachine.SetStateToChangeTo(this.SkeletonBattleStateMachine.AttackState);
    }
}