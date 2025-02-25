#nullable enable

namespace Game;

using UnityEngine;

partial class Player
{
    private abstract class GroundedState : State
    {
        protected GroundedState(Player player, string animationBoolName)
            : base(player, animationBoolName)
        {
        }

        protected sealed override void OnEnter()
        {
            this.OnGroundedEnter();
        }

        protected virtual void OnGroundedEnter()
        {
            // Leave this method blank
            // The derived classes can decide if they override this method
        }

        protected sealed override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.StateMachine?.ChangeState(this.Player.jumpState);
                return;
            }

            this.OnGroundedUpdate();
        }

        protected virtual void OnGroundedUpdate()
        {
            // Leave this method blank
            // The derived classes can decide if they override this method
        }

        protected sealed override void OnExit()
        {
            this.OnGroundedExit();
        }

        protected virtual void OnGroundedExit()
        {
            // Leave this method blank
            // The derived classes can decide if they override this method
        }
    }
}
