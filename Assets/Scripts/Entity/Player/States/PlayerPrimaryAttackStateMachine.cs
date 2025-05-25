#nullable enable

namespace Game;

using System.Collections.Generic;

public sealed class PlayerPrimaryAttackStateMachine : PlayerSpecificStateMachine
{
    public PlayerPrimaryAttackStateMachine(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;

        this.PlayerPrimaryAttack1State = new PlayerPrimaryAttack1State(this);
        this.PlayerPrimaryAttack2State = new PlayerPrimaryAttack2State(this);
        this.PlayerPrimaryAttack3State = new PlayerPrimaryAttack3State(this);

        this.PlayerPrimaryAttackStates = new PlayerPrimaryAttackState[] {
            this.PlayerPrimaryAttack1State,
            this.PlayerPrimaryAttack2State,
            this.PlayerPrimaryAttack3State,
        };
        this.PlayerPrimaryAttackStatesIt = this.PlayerPrimaryAttackStates.GetEnumerator();
    }

    public float ComboWindow => this.PlayerGeneralStateMachine.PrimaryAttackComboWindow;

    public float LastTimeAttacked { get; private set; } = 0;

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    protected override IEntityState InitialState
    {
        get
        {
            var lastTimeAttacked = this.LastTimeAttacked;
            var currentTime = UnityEngine.Time.time;
            this.LastTimeAttacked = currentTime;

            if (currentTime <= (lastTimeAttacked + this.ComboWindow) && this.PlayerPrimaryAttackStatesIt.MoveNext())
            {
                return this.PlayerPrimaryAttackStatesIt.Current;
            }

            this.PlayerPrimaryAttackStatesIt.Reset();
            if (this.PlayerPrimaryAttackStatesIt.MoveNext())
            {
                return this.PlayerPrimaryAttackStatesIt.Current;
            }

            return this.PlayerPrimaryAttack1State;
        }
    }

    public IEnumerable<PlayerPrimaryAttackState> PlayerPrimaryAttackStates { get; }

    public IEnumerator<PlayerPrimaryAttackState> PlayerPrimaryAttackStatesIt { get; }

    public PlayerPrimaryAttack1State PlayerPrimaryAttack1State { get; }

    public PlayerPrimaryAttack2State PlayerPrimaryAttack2State { get; }

    public PlayerPrimaryAttack3State PlayerPrimaryAttack3State { get; }
}
