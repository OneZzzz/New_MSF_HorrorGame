using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOnClick_Password : InteractionOnClickBase
{
    public PasswordController password;
    public override void Event()
    {
        password.Open(player);
    }
}
