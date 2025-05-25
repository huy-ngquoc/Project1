#nullable enable

namespace Game
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class PlayerThrowRegularSwordSkill : PlayerThrowSwordSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerThrowSwordSkillManager throwSwordSkillManager = null!;

        public sealed override PlayerThrowSwordSkillManager ThrowSwordSkillManager => this.throwSwordSkillManager;

        [field: SerializeField]
        [field: Range(1, 20)]
        public float RegularGravity { get; private set; } = 1;

        public override float SwordGravity => this.RegularGravity;

        protected sealed override void CastLogic()
        {
            var newSword = Object.Instantiate(
                this.SwordPrefab,
                this.PlayerController.transform.position,
                this.PlayerController.transform.rotation);
            if (newSword == null)
            {
                return;
            }

            if (!newSword.TryGetComponent<PlayerThrowRegularSwordSkillController>(out var swordController))
            {
                Debug.LogError($"Sword prefab {this.SwordPrefab.name} does not have a PlayerThrowRegularSwordSkillController component.");
                Object.Destroy(newSword);
                return;
            }

            this.throwSwordSkillManager.SetDotsActive(false);

            swordController.SetupSword(
                this.PlayerController,
                this.throwSwordSkillManager.ThrowDirection,
                this.SwordGravity,
                this.throwSwordSkillManager.FreezeTimeDuration,
                this.throwSwordSkillManager.ReturnSpeed);

            this.throwSwordSkillManager.AssignNewSwordController(swordController);
        }
    }
}
