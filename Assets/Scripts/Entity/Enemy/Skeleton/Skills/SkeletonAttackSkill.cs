#nullable enable

namespace Game
{
    public sealed class SkeletonAttackSkill : SkeletonSkill
    {
        protected override void CastLogic()
        {
            var skeletonGeneralStateMachine = this.SkeletonGeneralStateMachine;
            skeletonGeneralStateMachine.SetStateToChangeTo(skeletonGeneralStateMachine.AttackState);
        }
    }
}
