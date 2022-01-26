public interface IInput
{
    bool CharacterJump { get; }
    bool Dash { get; }
    bool EatGrass { get; }
    bool ChangeCharacterButton { get; }
    float HorizontalMove { get; }
    float VerticalMove { get; }
}