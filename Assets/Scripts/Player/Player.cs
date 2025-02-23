#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class Player : Entity
    {
        [field: Header("Move info")]
        [field: SerializeField, Range(1.0F, 30.0F)] public float MoveSpeed { get; private set; } = 8.0F;

        public PlayerStateMachine? StateMachine { get; private set; } = null;

        public PlayerIdleState? IdleState { get; private set; } = null;

        public PlayerMoveState? MoveState { get; private set; } = null;

        protected override void OnAwake()
        {
            this.IdleState = new PlayerIdleState(this, "Idle");
            this.MoveState = new PlayerMoveState(this, "Move");

            this.StateMachine = new PlayerStateMachine(this.IdleState);
        }

        protected override void OnUpdate()
        {
            this.StateMachine?.UpdateState();
        }

        #region Velocity

        public bool SetLinearVelocity(float x, float y)
        {
            return this.SetLinearVelocity(new Vector2(x, y));
        }

        public bool SetLinearVelocity(Vector2 newLinearVelocity)
        {
            if (this.Rigidbody2D != null)
            {
                this.Rigidbody2D.linearVelocity = newLinearVelocity;
                this.FlipController(newLinearVelocity.x);
                return true;
            }

            return false;
        }

        public bool SetZeroLinearVelocity() => this.SetLinearVelocity(Vector2.zero);

        public bool SetLinearVelocityX(float newLinearVelocityX)
        {
            if (this.Rigidbody2D != null)
            {
                this.Rigidbody2D.linearVelocityX = newLinearVelocityX;
                this.FlipController(newLinearVelocityX);
                return true;
            }

            return false;
        }

        public bool SetLinearVelocityY(float newLinearVelocityY)
        {
            if (this.Rigidbody2D != null)
            {
                this.Rigidbody2D.linearVelocityY = newLinearVelocityY;
                return true;
            }

            return false;
        }

        public Vector2? GetLinearVelocity()
        {
            Vector2? result = null;

            if (this.Rigidbody2D != null)
            {
                result = this.Rigidbody2D.linearVelocity;
            }

            return result;
        }

        public Vector2 GetLinearVelocityOrDefault(Vector2 defaultLinearVelocity)
            => this.GetLinearVelocity().GetValueOrDefault(defaultLinearVelocity);

        public Vector2 GetLinearVelocityOrZero()
          => this.GetLinearVelocityOrDefault(Vector2.zero);

        public float? GetLinearVelocityX()
        {
            float? result = null;

            if (this.Rigidbody2D != null)
            {
                result = this.Rigidbody2D.linearVelocityX;
            }

            return result;
        }

        public float GetLinearVelocityOrDefaultX(float defaultLinearVelocityX)
            => this.GetLinearVelocityX().GetValueOrDefault(defaultLinearVelocityX);

        public float GetLinearVelocityOrZeroX() => this.GetLinearVelocityOrDefaultX(0.0F);

        public float? GetLinearVelocityY()
        {
            float? result = null;

            if (this.Rigidbody2D != null)
            {
                result = this.Rigidbody2D.linearVelocityY;
            }

            return result;
        }

        public float GetLinearVelocityOrDefaultY(float defaultLinearVelocityY)
           => this.GetLinearVelocityY().GetValueOrDefault(defaultLinearVelocityY);

        public float GetLinearVelocityOrZeroY() => this.GetLinearVelocityOrDefaultY(0.0F);

        #endregion

    }
}
