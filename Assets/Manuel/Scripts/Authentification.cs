using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using System.Threading.Tasks;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Authentification : MonoBehaviour
{
    public Player_data player_Data;
    [SerializeField] private string email;
    [SerializeField] private string password;
    [SerializeField] private string Nombre;

    public List< TextMeshProUGUI> text_mensaje;

    private FirebaseAuth _authReference;

    public UnityEvent OnRegisterSuccesful = new UnityEvent();
    public UnityEvent OnLogInSuccesful = new UnityEvent();

    
    private void Awake()
    {
        _authReference = FirebaseAuth.GetAuth(FirebaseApp.DefaultInstance);
    }

    private void Start()
    {
       
    }

    public void Button_Registrarse()
    {
        Debug.Log("Start Register");
        StartCoroutine(RegisterUser(email, password));
    }
    public void Button_Iniciar_sesion()
    {
        Debug.Log("Start Login");
        StartCoroutine(SignInWithEmail(email, password));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LogOut();
        }
    }


    private IEnumerator RegisterUser(string email, string password)
    {
        Debug.Log("Registering");
        Task<AuthResult> registerTask = _authReference.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        
        if(registerTask.Exception != null)
        {
            
            Debug.LogWarning($"Failed to register task with {registerTask.Exception}");
        }
        else
        {
            Debug.Log($"Succesfully registered user {registerTask.Result.User.Email}");
            player_Data.Id_firebase = registerTask.Result.User.UserId;
            player_Data.Nombre = Nombre;
            OnRegisterSuccesful.Invoke();
        }
    }

    private IEnumerator SignInWithEmail(string email, string password)
    {
        Debug.Log("Loggin In");

        var loginTask = _authReference.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            Debug.LogWarning($"Login failed with {loginTask.Exception}");
        }
        else
        {
            Debug.Log($"Login succeeded with {loginTask.Result.User.Email}");
            player_Data.Id_firebase = loginTask.Result.User.UserId;
            OnLogInSuccesful.Invoke();
        }
        Debug.Log(loginTask.Result.User.UserId);
      
       
    }
    public void set_email(string email_)
    {
        email = email_;
    }
    public void set_password(string password_)
    {
        password = password_;
    }
    public void set_nombre(string nombre_)
    {
        Nombre = nombre_;
    }
    public void Mensaje(string mensaje_)
    {
        foreach (TextMeshProUGUI item in text_mensaje)
        {
            item.text = mensaje_;
        }
        
    }
    private void LogOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
