#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed partial class PlayerController : EntityController
    {
        private PlayerStateMachine? stateMachine = null;

        [field: Header("Move info")]

        [field: SerializeField]
        [field: Range(1, 30)]
        public float MoveSpeed { get; private set; } = 8;

        [field: SerializeField]
        [field: Range(1, 40)]
        public float JumpForce { get; private set; } = 12;

        protected override void OnAwake()
        {
            this.stateMachine = new PlayerStateMachine(this);
        }

        protected override void OnUpdate()
        {
            this.stateMachine?.UpdateState();
        }
    }
}
