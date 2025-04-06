#nullable enable

namespace Game;

using UnityEngine;

[RequireComponent(typeof(SkeletonSkillManager))]
public abstract class SkeletonSkill : EnemySkill
{
    [field: SerializeReference]
    [field: ResolveComponent]
    public SkeletonSkillManager SkeletonSkillManager { get; private set; } = null!;

    public SkeletonController SkeletonController => this.SkeletonSkillManager.SkeletonController;

    public SkeletonGeneralStateMachine SkeletonGeneralStateMachine => this.SkeletonController.SkeletonGeneralStateMachine;

    public sealed override EnemySkillManager EnemySkillManager => this.SkeletonSkillManager;
}
