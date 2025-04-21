#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerCloneSkill : PlayerSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerSkillManager playerSkillManager = null!;

        [field: Header("Clone info")]

        [field: SerializeField]
        private GameObject clonePrefab = null!;

        [field: SerializeField]
        [field: Range(0.1F, 5)]
        private float cloneDuration = 1;

        [field: SerializeField]
        private bool cloneCanAttack = false;

        public override PlayerSkillManager PlayerSkillManager => this.playerSkillManager;

        public void CreateClone(Vector2 clonePosition)
        {
            var newClone = Object.Instantiate(this.clonePrefab, clonePosition, Quaternion.identity);

            newClone.TryGetComponent<PlayerCloneSkillController>(out var cloneSkillController);
            if (cloneSkillController == null)
            {
                Debug.LogWarning($"Missing `{typeof(PlayerCloneSkillController).FullName}` component in clone prefab!");
                Object.Destroy(newClone);
                return;
            }

            var closestEnemyPosition = this.PlayerSkillManager.FindClosestEnemyTransform(clonePosition).UnityAccessVal(t => t.position);
            cloneSkillController.SetUpClone(this.PlayerController, clonePosition, this.cloneDuration, this.cloneCanAttack, closestEnemyPosition);
        }

        protected override void CastLogic()
        {
            this.CreateClone(this.PlayerController.transform.position);
        }
    }
}
