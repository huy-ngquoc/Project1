#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed partial class Player : Entity
    {
        private StateMachine? stateMachine = null;
        private IdleState? idleState = null;
        private MoveState? moveState = null;
        private JumpState? jumpState = null;
        private FallState? fallState = null;

        [field: Header("Move info")]

        [field: SerializeField]
        [field: Range(1, 30)]
        public float MoveSpeed { get; private set; } = 8;

        [field: SerializeField]
        [field: Range(1, 40)]
        public float JumpForce { get; private set; } = 12;

        protected override void OnAwake()
        {
            this.idleState = new IdleState(this, "Idle");
            this.moveState = new MoveState(this, "Move");
            this.jumpState = new JumpState(this, "Jump");
            this.fallState = new FallState(this, "Jump");

            this.stateMachine = new StateMachine(this.idleState);
        }

        protected override void OnUpdate()
        {
            this.stateMachine?.UpdateState();
        }
    }
}
