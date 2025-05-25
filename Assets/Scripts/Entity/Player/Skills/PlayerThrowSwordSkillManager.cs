#nullable enable

namespace Game
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    [DisallowMultipleComponent]
    public sealed class PlayerThrowSwordSkillManager : PlayerSpecificSkillManager
    {
        private GameObject[] dots = { };
        private PlayerThrowSwordSkillController? swordController = null;

        [field: Header("Player Aim Dot Parent")]
        [field: SerializeReference]
        [field: ResolveComponentInChildren("AimDotParent")]
        private Transform aimDotParentTransform = null!;

        [field: Header("Skill Details")]

        [field: SerializeField]
        [field: ResolveComponent]
        private PlayerThrowRegularSwordSkill throwRegularSwordSkill = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private PlayerThrowBounceSwordSkill throwBounceSwordSkill = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private PlayerThrowPeirceSwordSkill throwPeirceSwordSkill = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private PlayerThrowSpinSwordSkill throwSpinSwordSkill = null!;

        public enum SwordType
        {
            Regular,
            Bounce,
            Pierce,
            Spin,
        }

        [field: SerializeField]
        public SwordType CurrentSwordType { get; private set; } = SwordType.Regular;

        [field: Header("Skill info")]

        [field: SerializeField]
        public Vector2 LaunchForce { get; private set; } = new Vector2(35, 25);

        [field: SerializeField]
        [field: Range(0.1F, 2)]
        public float FreezeTimeDuration { get; private set; } = 1.5F;

        [field: SerializeField]
        [field: Range(5, 40)]
        public float ReturnSpeed { get; private set; } = 15;

        [field: SerializeField]
        [field: Range(1, 20)]
        public float ReturnImpact { get; private set; } = 7;

        public Vector2 AimDirection
        {
            get
            {
                var playerPosition = this.PlayerController.transform.position;
                var mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

                return mousePosition - playerPosition;
            }
        }

        public Vector2 ThrowDirection
        {
            get
            {
                var aimDirection = this.AimDirection;
                var aimDirectionNormalized = aimDirection.normalized;
                return new Vector2(
                        aimDirectionNormalized.x * this.LaunchForce.x,
                        aimDirectionNormalized.y * this.LaunchForce.y);
            }
        }

        public Vector2? SwordPosition
        {
            get
            {
                if (this.swordController == null)
                {
                    return null;
                }

                return this.swordController.transform.position;
            }
        }

        [field: Header("Aim dots")]

        [field: SerializeField]
        public GameObject DotPrefab { get; private set; } = null!;

        [field: SerializeField]
        [field: Range(10, 40)]
        public int NumberOfDots { get; private set; } = 20;

        [field: SerializeField]
        [field: Range(0.01F, 0.2F)]
        public float SpaceBetweenDots { get; private set; } = 0.07F;

        private PlayerThrowSwordSkill CurrentThrowSwordSkill
            => this.CurrentSwordType switch
            {
                SwordType.Regular => this.throwRegularSwordSkill,
                SwordType.Bounce => this.throwBounceSwordSkill,
                SwordType.Pierce => this.throwPeirceSwordSkill,
                SwordType.Spin => this.throwSpinSwordSkill,
                _ => this.throwRegularSwordSkill,
            };

        public void SetDotsActive(bool value)
        {
            foreach (var dot in this.dots)
            {
                dot.SetActive(value);
            }
        }

        public void SetDotsActive()
        {
            this.SetDotsActive(true);
        }

        public void SetDotsInactive()
        {
            this.SetDotsActive(false);
        }

        public void AssignNewSwordController(PlayerThrowSwordSkillController swordController)
        {
            if (this.swordController != null)
            {
                Object.Destroy(this.swordController.gameObject);
            }

            this.swordController = swordController;
        }

        public void ClearTheSword()
        {
            if (this.swordController != null)
            {
                Object.Destroy(this.swordController.gameObject);
                this.swordController = null;
            }
        }

        public bool HasSword()
        {
            return this.swordController != null;
        }

        public void ReturnTheSword()
        {
            if (this.swordController != null)
            {
                this.swordController.ReturnSword();
            }
        }

        public override bool IsUsable()
        {
            return this.CurrentThrowSwordSkill.IsUsable();
        }

        public override bool Cast()
        {
            return this.CurrentThrowSwordSkill.Cast();
        }

        protected override void OnPlayerSpecificSkillManagerAwake()
        {
            this.GenerateDots();
        }

        protected override void OnPlayerSpecificSkillManagerUpdate()
        {
            var aimSwordPressed = this.PlayerInputHandler.AimSwordPressed;
            if (this.IsUsable() && aimSwordPressed)
            {
                this.SetDotsPosition();
            }
        }

        private void GenerateDots()
        {
            this.dots = new GameObject[this.NumberOfDots];
            for (int i = 0; i < this.dots.Length; ++i)
            {
                this.dots[i] = Object.Instantiate(
                    this.DotPrefab,
                    this.aimDotParentTransform.position,
                    Quaternion.identity,
                    this.aimDotParentTransform.transform);
                this.dots[i].SetActive(false);
            }
        }

        private void SetDotsPosition()
        {
            for (int i = 0; i < this.dots.Length; ++i)
            {
                var t = i * this.SpaceBetweenDots;
                var aimDirection = this.AimDirection;
                var aimDirectionNormalized = aimDirection.normalized;
                var dotPosition = (Vector2)this.PlayerController.transform.position
                   + (new Vector2(
                       aimDirectionNormalized.x * this.LaunchForce.x,
                       aimDirectionNormalized.y * this.LaunchForce.y) * t)
                   + (0.5F * (t * t) * this.CurrentThrowSwordSkill.SwordGravity * Physics2D.gravity);
                this.dots[i].transform.position = dotPosition;
            }
        }
    }
}
