using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    public GameObject Register;
    public GameObject Login;

    public void onPressRegister()
    {
        Login.SetActive(false);
        Register.SetActive(true);
    }

    public void onPressBack()
    {
        Login.SetActive(true);
        Register.SetActive(false);
    }
}
