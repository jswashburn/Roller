public interface ICharacterController<TMoveOption> where TMoveOption : IMoveOption
{
    void Control(TMoveOption moveOption);
}