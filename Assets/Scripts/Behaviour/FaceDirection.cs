using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : AbstractBehaviour
{
    void Update()
    {
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);

        if (right)
            inputState.directions = Directions.Right;
        else if (left)
                    inputState.directions = Directions.Left;

        transform.localScale = new Vector3((float)inputState.directions, 1, 1);
    }
}
