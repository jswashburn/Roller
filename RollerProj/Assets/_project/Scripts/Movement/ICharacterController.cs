public interface ICharacterController<in TMoveOption>
{
    void Move(TMoveOption moveOption);
}