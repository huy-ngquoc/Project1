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

        public static string Attack { get; } = nameof(Attack);

        public static string PrimaryAttack1 { get; } = nameof(PrimaryAttack1);

        public static string PrimaryAttack2 { get; } = nameof(PrimaryAttack2);

        public static string PrimaryAttack3 { get; } = nameof(PrimaryAttack3);
    }

    public static class Float
    {
        public static string VelocityY { get; } = nameof(VelocityY);
    }
}
