using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button m_jumpButton;
    [SerializeField] private Player m_player;

    void Start()
    {
        m_jumpButton.onClick.AddListener(() =>
        {
            m_player.Jump();
        });
    }
}
