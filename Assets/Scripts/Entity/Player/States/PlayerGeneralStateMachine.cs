#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerGeneralStateMachine : EntityGeneralStateMachine
    {
        public PlayerGeneralStateMachine()
        {
            this.GroundedState = new PlayerGroundedStateMachine(this);
            this.JumpState = new PlayerJumpState(this);
            this.FallState = new PlayerFallState(this);
            this.PrimaryAttackState = new PlayerPrimaryAttackStateMachine(this);
            this.DashState = new PlayerDashState(this);
            this.AimSwordState = new PlayerAimSwordState(this);
            this.CatchSwordState = new PlayerCatchSwordState(this);
            this.DeadState = new PlayerDeadState(this);
        }

        [field: Header("Controller")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerController PlayerController { get; private set; } = null!;

        [field: Header("Primary attack state")]
        [field: SerializeField]
        [field: Range(0.5F, 5.0F)]
        public float PrimaryAttackComboWindow { get; private set; } = 2;

        public sealed override EntityController EntityController => this.PlayerController;

        public sealed override IEntityState InitialState => this.GroundedState;

        public PlayerGroundedStateMachine GroundedState { get; }

        public PlayerJumpState JumpState { get; }

        public PlayerFallState FallState { get; }

        public PlayerPrimaryAttackStateMachine PrimaryAttackState { get; }

        public PlayerDashState DashState { get; }

        public PlayerAimSwordState AimSwordState { get; }

        public PlayerCatchSwordState CatchSwordState { get; }

        public PlayerDeadState DeadState { get; }
    }
}
