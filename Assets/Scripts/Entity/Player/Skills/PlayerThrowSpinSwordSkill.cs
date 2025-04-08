#nullable enable

namespace Game
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class PlayerThrowSpinSwordSkill : PlayerThrowSwordSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerThrowSwordSkillManager throwSwordSkillManager = null!;

        public sealed override PlayerThrowSwordSkillManager ThrowSwordSkillManager => this.throwSwordSkillManager;

        [field: Header("Spin info")]

        [field: SerializeField]
        [field: Range(5, 30)]
        public float MaxTravelDistance { get; private set; } = 7;

        [field: SerializeField]
        [field: Range(0.5F, 5)]
        public float SpinDuration { get; private set; } = 2;

        [field: SerializeField]
        [field: Range(0.01F, 2)]
        public float SpinGravity { get; private set; } = 1;

        public override float SwordGravity => this.SpinGravity;

        [field: SerializeField]
        [field: Range(0.05F, 0.5F)]
        public float HitCooldown { get; private set; } = 0.35F;

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

            if (!newSword.TryGetComponent<PlayerThrowSpinSwordSkillController>(out var swordController))
            {
                Debug.LogError($"Sword prefab {this.SwordPrefab.name} does not have a PlayerThrowSpinSwordSkillController component.");
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
            swordController.SetupSpin(this.MaxTravelDistance, this.SpinDuration, this.HitCooldown);

            this.throwSwordSkillManager.AssignNewSwordController(swordController);
        }
    }
}
