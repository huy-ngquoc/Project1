#nullable enable

namespace Game;

public static class AnimationNameConstants
{
    public static class Bool
    {
        public static string Idle { get; } = nameof(Idle);

        public static string Move { get; } = nameof(Move);

        public static string Jump { get; } = nameof(Jump);

        public static string Fall { get; } = Jump;

        public static string Dash { get; } = nameof(Dash);

        public static string AimSword { get; } = nameof(AimSword);

        public static string CatchSword { get; } = nameof(CatchSword);

        public static string Attack { get; } = nameof(Attack);

        public static string Rotation { get; } = nameof(Rotation);

        public static string PrimaryAttack1 { get; } = nameof(PrimaryAttack1);

        public static string PrimaryAttack2 { get; } = nameof(PrimaryAttack2);

        public static string PrimaryAttack3 { get; } = nameof(PrimaryAttack3);

        public static string Dead { get; } = nameof(Dead);

        public static class PlayerClone
        {
            public static string Attack1 { get; } = nameof(Attack1);

            public static string Attack2 { get; } = nameof(Attack2);

            public static string Attack3 { get; } = nameof(Attack3);
        }
    }

    public static class Float
    {
        public static string VelocityY { get; } = nameof(VelocityY);
    }
}
