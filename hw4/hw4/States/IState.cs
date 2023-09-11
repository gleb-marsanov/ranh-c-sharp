namespace hw4.States;

public interface IBaseState
{
}

public interface IState : IBaseState
{
    Task Enter();
}

public interface IPayloadState<in TPayload> : IBaseState
{
    Task Enter(TPayload payload);
}