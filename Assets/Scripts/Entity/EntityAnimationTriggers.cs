#nullable enable

namespace Game
{
    using UnityEngine;
    using MonoBehaviour = UnityEngine.MonoBehaviour;

    public abstract class EntityAnimationTriggers : MonoBehaviour
    {
        [SerializeField] protected HealthController healthController;
        
        public abstract EntityController EntityController { get; }

        private void AnimationFinishTrigger() => this.EntityController.AnimationFinishTrigger();

        private void AnimationAttackTrigger()
        {
            var entityController = this.EntityController;
            var colliders = Physics2D.OverlapCircleAll(entityController.AttackCheck.transform.position, entityController.AttackCheckRadius, entityController.AttackTargetLayerMask);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<EntityStats>(out var targetStats))
                {
                    this.EntityController.EntityStats.DoDamage(targetStats);
                }
                if(collider.TryGetComponent<EnemyStateManager>(out var enemyStateManager)) {
                    enemyStateManager.GetHealthController().TakeDamage(healthController.TakeDamageAt(0));
                    enemyStateManager.TakeDamage();
                }
            }
        }
    }
}
