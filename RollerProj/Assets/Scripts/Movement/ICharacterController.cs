namespace Roller.Movement
{
    public interface ICharacterController<in TMoveOption> where TMoveOption : IMoveOption
    {
        void Control(TMoveOption moveOption);
    }
}