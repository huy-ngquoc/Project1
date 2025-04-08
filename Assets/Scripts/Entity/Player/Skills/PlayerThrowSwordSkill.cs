#nullable enable

namespace Game
{
    using UnityEngine;

    public abstract class PlayerThrowSwordSkill : PlayerSkill
    {
        public abstract PlayerThrowSwordSkillManager ThrowSwordSkillManager { get; }

        public sealed override PlayerSkillManager PlayerSkillManager => this.ThrowSwordSkillManager.PlayerSkillManager;

        [field: SerializeReference]
        public GameObject SwordPrefab { get; private set; } = null!;

        public abstract float SwordGravity { get; }

        protected sealed override bool IsUsablePlayerSkill()
        {
            return (!this.ThrowSwordSkillManager.HasSword()) && this.IsUsablePlayerThrowSwordSkill();
        }

        protected virtual bool IsUsablePlayerThrowSwordSkill()
        {
            return true;
        }

        protected sealed override void OnPlayerSkillAwake()
        {
            this.OnPlayerThrowSwordSkillAwake();
        }

        protected virtual void OnPlayerThrowSwordSkillAwake()
        {
        }

        protected sealed override void OnPlayerSkillUpdate()
        {
            this.OnPlayerThrowSwordSkillUpdate();
        }

        protected virtual void OnPlayerThrowSwordSkillUpdate()
        {
        }
    }
}
