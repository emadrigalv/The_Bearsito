using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerConfig_SO", menuName = "Player config")]
public class PlayerConfig_SO : ScriptableObject
{

    public string playerName;
    public int initialLives;
    public float speed;
    public int jumpForce;
    public float coyoteTime;
    
}
