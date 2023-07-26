
namespace BOOM
{
    public interface IStates 
    {
       void Begin(StateManager stateManager);
       void Exit();
    }
}
