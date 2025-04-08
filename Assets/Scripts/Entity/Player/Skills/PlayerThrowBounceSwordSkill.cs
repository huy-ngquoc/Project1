#nullable enable

namespace Game
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class PlayerThrowBounceSwordSkill : PlayerThrowSwordSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerThrowSwordSkillManager throwSwordSkillManager = null!;

        public sealed override PlayerThrowSwordSkillManager ThrowSwordSkillManager => this.throwSwordSkillManager;

        [field: Header("Bounce info")]

        [field: SerializeField]
        [field: Range(1, 20)]
        public byte BounceAmount { get; private set; } = 4;

        [field: SerializeField]
        [field: Range(1, 20)]
        public float BounceGravity { get; private set; } = 1;

        public override float SwordGravity => this.BounceGravity;

        [field: SerializeField]
        [field: Range(5, 40)]
        public float BounceSpeed { get; private set; } = 20;

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

            if (!newSword.TryGetComponent<PlayerThrowBounceSwordSkillController>(out var swordController))
            {
                Debug.LogError($"Sword prefab {this.SwordPrefab.name} does not have a PlayerThrowBounceSwordSkillController component.");
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

            swordController.SetupBounce(this.BounceAmount, this.BounceSpeed);

            this.throwSwordSkillManager.AssignNewSwordController(swordController);
        }
    }
}
