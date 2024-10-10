using System;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using Unity.PlasticSCM.Editor.WebApi;
=======
using Unity.VisualScripting;
>>>>>>> main
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    //Static means it can be called from anywhere.
    public static LevelManager main;

<<<<<<< HEAD
    public Transform startPoint;
    public Transform[] path;
    public Transform targetPoint;
=======
    [SerializeField] public Transform[] startPoint;
    [SerializeField] public List<Transform> path1;
    [SerializeField] public List<Transform> path2;
    [SerializeField] public List<Transform> path3;
    [SerializeField] public GameObject CandyPile;

    
>>>>>>> main

    public int currency;

    private void Awake()
    {
        main = this;
        //Adding the Candy Pile transform to the end of the list for the AI pathing.
        path1.Add(CandyPile.transform);
        path2.Add(CandyPile.transform);
        path3.Add(CandyPile.transform);
        //path1.AddRange(new Transform[] { targetPoint });
        //path2.AddRange(new Transform[] { targetPoint });

    }

    private void Start()
    {
        //Game starts with 100
        currency = 100;
    }

    public void GainMoney(int cash)
    {
        //Called in the EnemyCtrl to gain Money
        currency += cash;
    }

    //This is where the UI comes in
    public bool SpendMoney(int cash)
    {
        if(cash <= currency)
        {
            //Buy Torrent
            currency -= cash;
            return true;
        } else
        {
            Debug.Log("Not enough cash");
            return false;
        }
    }
}
