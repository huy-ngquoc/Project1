#nullable enable

namespace Game
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class PlayerThrowPeirceSwordSkill : PlayerThrowSwordSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerThrowSwordSkillManager throwSwordSkillManager = null!;

        public sealed override PlayerThrowSwordSkillManager ThrowSwordSkillManager => this.throwSwordSkillManager;

        [field: Header("Peirce info")]

        [field: SerializeField]
        [field: Range(1, 10)]
        public byte PeirceAmount { get; private set; } = 2;

        [field: SerializeField]
        [field: Range(0.01F, 2)]
        public float PeirceGravity { get; private set; } = 0.5F;

        public override float SwordGravity => this.PeirceGravity;

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

            if (!newSword.TryGetComponent<PlayerThrowPeirceSwordSkillController>(out var swordController))
            {
                Debug.LogError($"Sword prefab {this.SwordPrefab.name} does not have a PlayerThrowPeirceSwordSkillController component.");
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
            swordController.SetupPierce(this.PeirceAmount);

            this.throwSwordSkillManager.AssignNewSwordController(swordController);
        }
    }
}
