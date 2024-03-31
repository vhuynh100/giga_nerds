using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using TMPro;
using Firebase;
using UnityEngine;

public class AuthManager : MonoBehaviour
{

    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    [Header("Login Input")]
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_Text warning;
    public TMP_Text success;

    [Header("Register")]
    public TMP_InputField username;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField passwordVerify;
    public TMP_Text warningReg;
    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else { Debug.LogError("Could not resolve dependencies: " + dependencyStatus); }
        });
    }
    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase");

        auth = FirebaseAuth.DefaultInstance;

    }

    public void LoginButton()
    {
        StartCoroutine(Login(emailField.text, passwordField.text));
    }

    public void RegisterButton()
    {
        StartCoroutine(Register(emailInput.text, passwordInput.text, username.text));
    }

    private IEnumerator Login(string _email, string _password)
    {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: ()=> LoginTask.IsCompleted);

        if(LoginTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException ex = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)ex.ErrorCode;

            string message = "Login Failed";

            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist - Register below";
                    break;
            }
            warning.text = message;
        }
        user = LoginTask.Result.User;
        success.text = "Logged In";
    }
    
    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            warningReg.text = "Missing Username";
        }
        else if (passwordInput.text != passwordVerify.text)
        {
            warningReg.text = "Passwords do not match";
        }
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);

            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if(RegisterTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to Register with {RegisterTask.Exception}");
                FirebaseException ex = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)ex.ErrorCode;

                string message = "";

                switch (errorCode)
                {
                    case AuthError.InvalidEmail:
                        message = "Invalid Email"; break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email in use"; break;
                    case AuthError.WeakPassword:
                        message = "Weak password"; break;
                    case AuthError.MissingPassword:
                        message = "Missing Password"; break;
                }
                warningReg.text = message;
            }
            else
            {
                user = RegisterTask.Result.User;
                if(user != null)
                {
                    UserProfile profile = new UserProfile();
                    profile.DisplayName = _username;

                    var profileTask = user.UpdateUserProfileAsync(profile);

                    yield return new WaitUntil(predicate: () => profileTask.IsCompleted);

                    if(profileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Profile failed with error: {profileTask.Exception}");
                        warningReg.text = "Username Set Failed!";
                    }
                }
            }
        }
        
    }
}
