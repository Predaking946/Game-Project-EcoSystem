using UnityEngine;

public class Game_Input : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        //Enables Unity action map "Player"
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        //Sets the value in the section "Movement" in the action map "Player" to InputVector
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        //Makes so that going diagonal is not faster than moving on one vector
        inputVector = inputVector.normalized;

        Debug.Log(inputVector);
        return inputVector;
    }
}