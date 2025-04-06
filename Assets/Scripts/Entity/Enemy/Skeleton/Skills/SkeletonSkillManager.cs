#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonController))]
    public sealed class SkeletonSkillManager : EnemySkillManager
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public override EnemyController EnemyController => this.SkeletonController;

        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonAttackSkill AttackSkill { get; private set; } = null!;
    }
}
