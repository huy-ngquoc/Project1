#nullable enable

namespace Game
{
    using UnityEngine;
    using MonoBehaviour = UnityEngine.MonoBehaviour;

    public abstract class EntityAnimationTriggers : MonoBehaviour
    {
        public abstract EntityController EntityController { get; }

        private void AnimationFinishTrigger() => this.EntityController.AnimationFinishTrigger();

        private void AnimationAttackTrigger()
        {
            var entityController = this.EntityController;
            var colliders = Physics2D.OverlapCircleAll(entityController.AttackCheck.transform.position, entityController.AttackCheckRadius, entityController.AttackTargetLayerMask);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<EntityController>(out var targetEntityController))
                {
                    targetEntityController.EntityStats.TakeDamage();
                }
                if(collider.TryGetComponent<EnemyStateManager>(out var enemyStateManager)) {
                    enemyStateManager.ChangeState(new DamageState(enemyStateManager));
                }
            }
        }
    }
}
