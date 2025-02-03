using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;

public class Movimento : MonoBehaviour {
    public float velocidade = 5f;

    [SerializeField]
    private InputActionReference movimento;

    private void Update() {
        transform.Translate(movimento.action.ReadValue<Vector2>() * velocidade / 1000);
    }
}
