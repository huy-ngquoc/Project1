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
        }

        [field: Header("Primary attack state")]
        [field: SerializeField]
        [field: Range(0.5F, 5.0F)]
        public float PrimaryAttackComboWindow { get; private set; } = 2;

        [field: Header("Controller")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerController PlayerController { get; private set; } = null!;

        public sealed override EntityController EntityController => this.PlayerController;

        public sealed override IEntityState InitialState => this.GroundedState;

        public PlayerGroundedStateMachine GroundedState { get; }

        public PlayerJumpState JumpState { get; }

        public PlayerFallState FallState { get; }

        public PlayerPrimaryAttackStateMachine PrimaryAttackState { get; }
    }
}
