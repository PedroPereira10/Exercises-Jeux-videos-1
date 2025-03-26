using UnityEngine;

public enum States
{
    idle,Patrol,Pursuit
};

public class StateMachine : MonoBehaviour
{
    private BaseState _currentState;

    public void ChangeState(BaseState state)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = state;
        _currentState.Enter();
    }

    public BaseState GetCurrentState()
    {
        return _currentState;
    }

    private void Update()
    {
        if (_currentState != null)
        { 
            _currentState.Update();
        }
    }
}
