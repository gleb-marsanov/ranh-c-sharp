namespace hw4.States;

public interface IBaseState
{
}

public interface IState : IBaseState
{
    void Enter();
}

public interface IPayloadState<in TPayload> : IBaseState
{
    void Enter(TPayload payload);
}