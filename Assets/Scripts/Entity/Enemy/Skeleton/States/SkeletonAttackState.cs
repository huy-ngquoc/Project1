#nullable enable

namespace Game;

public sealed class SkeletonAttackState : SkeletonState
{
    public SkeletonAttackState(SkeletonGeneralStateMachine skeletonGeneralStateMachine)
    {
        this.SkeletonGeneralStateMachine = skeletonGeneralStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Attack;

    public override SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    protected override void OnSkeletonStateUpdate()
    {
        if (this.TriggerCalled)
        {
            var generalStateMachine = this.SkeletonGeneralStateMachine;
            var playerRaycastHit2D = this.SkeletonController.IsPlayerDetected;

            if (playerRaycastHit2D
                && (playerRaycastHit2D.distance <= this.SkeletonController.AttackRange))
            {
                generalStateMachine.SetStateToChangeTo(generalStateMachine.IdleState);
            }
            else
            {
                generalStateMachine.SetStateToChangeTo(generalStateMachine.MoveState);
            }
        }
    }
}
