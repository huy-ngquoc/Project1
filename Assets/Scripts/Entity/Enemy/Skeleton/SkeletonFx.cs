#nullable enable

namespace Game
{
    public sealed class SkeletonFx : EnemyFx
    {
        [field: UnityEngine.SerializeReference]
        [field: ResolveComponentInParent]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public override EnemyController EnemyController => this.SkeletonController;
    }
}
