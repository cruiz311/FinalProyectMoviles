using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;

public class Database_firebase : MonoBehaviour
{
    public static Database_firebase instance;
    private DatabaseReference databaseReference;
    
    public Player_data player_Data;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //INSTRUCCIONES
    //--PARA ACCEDER AL NIVEL DEL USUARIO Get_Nivel
    // CODIGO: Database_firebase.instance.Get_Nivel(funcion con parametro int que recibira el nivel);

    //--PARA ENVIAR EL NIVEL A DATABASE FIREBASE
    //CODIGO:  Database_firebase.instance.Set_Nivel(valor);

    //Y LO MISMO PARA NOMBRE

    public void Create_user()
    {
        //databaseReference.Child("Users").Child(userID).SetValueAsync(userID);
        Set_Nombre(player_Data.Nombre);
        Set_Nivel(1);
        Set_Puntos_experiencia(0);
        Set_Puntos_maximo_experiencia(10);
        Set_Energia(20);
        Set_Energia_maxima(20);
        Set_Puntos_magia(0);
    }
    public void Get_player_data()
    {
        Get_Nombre(player_Data.Set_Nombre);
        Get_Nivel(player_Data.Set_Nivel);
        Get_Puntos_experiencia(player_Data.Set_Puntos_experiencia);
        Get_Puntos_maximo_experiencia(player_Data.Set_Puntos_maximo_experiencia);
        Get_Energia(player_Data.Set_Energia);
        Get_Energia_maxima(player_Data.Set_Energia_maxima);
        Get_Puntos_magia(player_Data.Set_Puntos_magia);
    }
    
   
    
    public IEnumerator Get_Variable_string_de_Users(string nombre_variable,Action<string> onCallBack)
    {
        var userNameData = databaseReference.Child("Users").Child(player_Data.Id_firebase).Child(nombre_variable).GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            
            onCallBack.Invoke(snapshot.Value.ToString());

        }
    }
    public IEnumerator Get_Variable_int_de_Users(string nombre_variable, Action<int> onCallBack)
    {
        var userNameData = databaseReference.Child("Users").Child(player_Data.Id_firebase).Child(nombre_variable).GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            
            onCallBack.Invoke(int.Parse(snapshot.Value.ToString()));

        }
    }
    public void Get_Nombre(Action<string> onCallBack)
    {
        StartCoroutine(Get_Variable_string_de_Users("Nombre", onCallBack));

    }
    public void Get_Nivel(Action<int> onCallBack)
    {
        StartCoroutine(Get_Variable_int_de_Users("Nivel", onCallBack));
    }
    public void Get_Puntos_experiencia(Action<int> onCallBack)
    {
        StartCoroutine(Get_Variable_int_de_Users("Puntos_experiencia", onCallBack));
    }
    public void Get_Puntos_maximo_experiencia(Action<int> onCallBack)
    {
        StartCoroutine(Get_Variable_int_de_Users("Puntos_maximo_experiencia", onCallBack));
    }
    public void Get_Energia(Action<int> onCallBack)
    {
        StartCoroutine(Get_Variable_int_de_Users("Energia", onCallBack));
    }
    public void Get_Energia_maxima(Action<int> onCallBack)
    {
        StartCoroutine(Get_Variable_int_de_Users("Energia_maxima", onCallBack));
    }
    public void Get_Puntos_magia(Action<int> onCallBack)
    {
        StartCoroutine(Get_Variable_int_de_Users("Puntos_magia", onCallBack));
    }



    public void Set_Nombre(string Nombre)
    {
        player_Data.Nombre = Nombre;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nombre").SetValueAsync(Nombre);
    }
    public void Set_Nivel(int Nivel)
    {
        player_Data.Nivel = Nivel;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nivel").SetValueAsync(Nivel);
    }
    public void Set_Puntos_experiencia(int Puntos_experiencia)
    {
        player_Data.Puntos_experiencia = Puntos_experiencia;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Puntos_experiencia").SetValueAsync(Puntos_experiencia);
    }
    public void Set_Puntos_maximo_experiencia(int Puntos_maximo_experiencia)
    {
        player_Data.Puntos_experiencia = Puntos_maximo_experiencia;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Puntos_maximo_experiencia").SetValueAsync(Puntos_maximo_experiencia);
    }
    public void Set_Energia(int Energia)
    {
        player_Data.Energia = Energia;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Energia").SetValueAsync(Energia);
    }
    public void Set_Energia_maxima(int Energia_maxima)
    {
        player_Data.Energia_maxima = Energia_maxima;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Energia_maxima").SetValueAsync(Energia_maxima);
    }
    public void Set_Puntos_magia(int Puntos_magia)
    {
        player_Data.Puntos_magia = Puntos_magia;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Puntos_magia").SetValueAsync(Puntos_magia);
    }



    //private IEnumerator GetCodeID(Action<int> onCallBack)
    //{
    //    var userNameData = databaseReference.Child("users").Child(userID).Child(nameof(User.codeID)).GetValueAsync();

    //    yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

    //    if (userNameData != null)
    //    {
    //        DataSnapshot snapshot = userNameData.Result;
    //        //(int) -> Casting
    //        //int.Parse -> Parsing
    //        //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
    //        onCallBack?.Invoke(int.Parse(snapshot.Value.ToString()));
    //    }
    //}
}
