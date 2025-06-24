using UnityEngine;
using System;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public PlayableCharacterData activeCharacter;
    public DamageReceiver damageReceiver;

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

}
