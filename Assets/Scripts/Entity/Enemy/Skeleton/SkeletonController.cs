#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonGeneralStateMachine))]
    public sealed class SkeletonController : EnemyController
    {
        [field: Header("Skeleton State machine")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; private set; } = null!;

        public sealed override EnemyGeneralStateMachine EnemyGeneralStateMachine => this.SkeletonGeneralStateMachine;

        [field: Header("Skeleton Stats")]
        [field: SerializeField]
        [field: ResolveComponent]
        public SkeletonStats SkeletonStats { get; private set; } = null!;

        public override EnemyStats EnemyStats => this.SkeletonStats;

        [field: Header("Skeleton FX")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonFx SkeletonFx { get; private set; } = null!;

        public override EnemyFx EnemyFx => this.SkeletonFx;

        [field: Header("Skeleton skill manager")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonSkillManager SkeletonSkillManager { get; private set; } = null!;

        public override EnemySkillManager EnemySkillManager => this.SkeletonSkillManager;

        public override void Die()
        {
            this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGeneralStateMachine.DeadState);
            Debug.Log("Call die function");
            MenuManagerScript.GetInstance().IncreaseDestroyedMonster();
        }

        protected override void OnEnemyControllerAwake()
        {
            int difficulty = PlayerPrefs.GetInt("Difficulty", -1);
            if (difficulty == 1)
            {
                this.MoveSpeed = 10.0f;
            }
        }
    }
}
