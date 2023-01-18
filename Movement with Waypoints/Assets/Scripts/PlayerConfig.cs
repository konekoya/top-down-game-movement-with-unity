using System.Collections.Generic;

[System.Serializable]
public class PlayerConfig
{
    public Dictionary<string, string> animationState = new Dictionary<string, string>()
    {
        {"moveLeft" , "Move_Left"},
       { "moveRight" , "Move_Right"},
        {"moveBack" , "Move_Back"},
        {"moveFront" , "Move_Front"},
        {"idleLeft" , "Idle_Left"},
        {"idleRight" , "Idle_Right"},
        {"idleBack" , "Idle_Back"},
        {"idleFront" , "Idle_Front"},
    };
}
