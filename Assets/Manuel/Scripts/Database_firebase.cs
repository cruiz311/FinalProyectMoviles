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
        Set_Nivel(0);
    }
    public void Get_player_data()
    {
        StartCoroutine(Get_Nombre());
        StartCoroutine(Get_Nivel());
    }
    private IEnumerator Get_Nombre()
    {
        var userNameData = databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nombre").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            player_Data.Nombre = snapshot.Value.ToString();

        }
    }
    public IEnumerator Get_Nombre(Action<string> onCallBack)
    {
        var userNameData = databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nombre").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            //player_Data.Nombre = snapshot.Value.ToString();
            onCallBack.Invoke(snapshot.Value.ToString());
        }
    }
    private IEnumerator Get_Nivel()
    {
        var userNameData = databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nivel").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            player_Data.Nivel = int.Parse(snapshot.Value.ToString());

        }
    }
    public IEnumerator Get_Nivel(Action<int> onCallBack)
    {
        var userNameData = databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nivel").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            //player_Data.Nivel = int.Parse(snapshot.Value.ToString());
            onCallBack.Invoke(int.Parse(snapshot.Value.ToString()));

        }
    }
    public void Set_Nombre(string nombre_)
    {
        player_Data.Nombre = nombre_;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nombre").SetValueAsync(nombre_);
    }
    public void Set_Nivel(int nivel_)
    {
        player_Data.Nivel = nivel_;
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nivel").SetValueAsync(nivel_);
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
