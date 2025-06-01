#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonController))]
    public sealed class SkeletonStats : EnemyStats
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public sealed override EnemyController EnemyController => this.SkeletonController;
        public void Awake() {
            int difficulty =PlayerPrefs.GetInt("Difficulty",-1);
            if(difficulty==1) { 
                this.MaxHealth = 300;
            } 
            this.CurrentHealth = this.MaxHealth;
        this.OnHealthChanged?.Invoke();
        }
        protected override void OnEnemyTakeDamage()
        {
            Debug.Log("Skeleton is damaged!");
        }
    }
}