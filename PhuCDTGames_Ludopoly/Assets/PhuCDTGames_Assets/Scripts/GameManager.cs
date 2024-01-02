using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Table _Table;
    public UIManager _UIManager;

    void Start()
    {
        //Loading Screen
        //After a while, call this
        IEnumerator LoadingScreen()
        {
            print("Loading");
            yield return new WaitForSeconds(3f);
            _Table.ChooseStartingPlayer();
        }
        StartCoroutine(LoadingScreen());
    }



}
