using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    public float vmove { get; private set; }    
    public float hmove { get; private set; }
    public bool jump { get; private set; }
    public bool fire { get; private set; }

    private string moveVAxis = "Vertical";
    private string moveHAxis = "Horizontal";
    //private string jumpButtonName = "Jump";
    private string fireButtonName = "Fire1";

    void Update()
    {
#if UNITY_EDITOR_WIN

        vmove = Input.GetAxis(moveVAxis);
        hmove = Input.GetAxis(moveHAxis);
        //jump = Input.GetButtonDown(jumpButtonName);
        fire = Input.GetButtonDown(fireButtonName);
#endif

#if UNITY_ANDROID
        vmove = CrossPlatformInputManager.GetAxis(moveVAxis);
        hmove=CrossPlatformInputManager.GetAxis(moveHAxis);
        fire = CrossPlatformInputManager.GetButtonDown(fireButtonName);
#endif
    }


}
