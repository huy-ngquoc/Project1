#nullable enable

namespace Game;

public sealed class SkeletonIdleState : SkeletonState
{
    public SkeletonIdleState(SkeletonGeneralStateMachine skeletonGeneralStateMachine)
    {
        this.SkeletonGeneralStateMachine = skeletonGeneralStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Idle;

    public override SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    protected override void OnSkeletonStateEnter()
    {
        this.StateTimer = this.SkeletonGeneralStateMachine.IdleTime;
    }

    protected override void OnSkeletonStateUpdate()
    {
        var playerRaycastHit2D = this.SkeletonController.IsPlayerDetected;
        if (playerRaycastHit2D)
        {
            if (playerRaycastHit2D.distance <= this.SkeletonController.AttackRange)
            {
                this.SkeletonSkillManager.AttackSkill.Cast();
            }
            else
            {
                var generalStateMachine = this.SkeletonGeneralStateMachine;
                generalStateMachine.SetStateToChangeTo(generalStateMachine.MoveState);
            }

            return;
        }

        if (this.StateTimer <= 0)
        {
            var generalStateMachine = this.SkeletonGeneralStateMachine;
            generalStateMachine.SetStateToChangeTo(generalStateMachine.MoveState);
        }
    }
}
