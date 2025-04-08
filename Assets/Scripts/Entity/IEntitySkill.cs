#nullable enable

namespace Game;

public interface IEntitySkill
{
    EntitySkillManager EntitySkillManager { get; }

    bool IsUsable();

    bool Cast();
}
