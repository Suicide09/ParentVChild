using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI currencyUI;
    [SerializeField] private Animator anim;
    [SerializeField] private Button menuButton;

    private bool isMenuOpen = true;

    //This is for the menu animation
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen) anim.Play("MenuClose"); else anim.Play("MenuOpen");
    }

    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.GetCurrency().ToString();
    }

    //This is where the currency system works
    public void setSelected()
    {

    }

    private void Start()
    {
        menuButton.onClick.AddListener(ToggleMenu);
    }
}
