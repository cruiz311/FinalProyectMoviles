using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;

public class Database_firebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private string userID;
    public Player_data player_Data;
    // Start is called before the first frame update
    private void Awake()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }
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
    public void Set_Nombre(string nombre_)
    {
        databaseReference.Child("Users").Child(player_Data.Id_firebase).Child("Nombre").SetValueAsync(nombre_);
    }
    public void Set_Nivel(int nivel_)
    {
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
