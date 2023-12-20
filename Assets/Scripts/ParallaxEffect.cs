using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ParallaxLayer
{
    [SerializeField] private SpriteRenderer m_layerReference;
    [SerializeField] private float m_ratio;

    public float Ratio { get { return m_ratio; } }
    public SpriteRenderer LayerReference { get { return m_layerReference; } }
}

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private List<ParallaxLayer> m_parallaxLayers;

    private Vector3 m_initialMousePos;
    private Vector3 m_finalMousePos;
    private Vector2 delta;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_initialMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            m_finalMousePos = Input.mousePosition;
            delta = m_finalMousePos - m_initialMousePos;
        }

        foreach (var layer in m_parallaxLayers)
        {
            layer.LayerReference.transform.Translate(new Vector2(delta.x * layer.Ratio * Time.deltaTime, 0));

            if (Mathf.Abs(layer.LayerReference.transform.position.x) >= layer.LayerReference.size.x)
            {
                layer.LayerReference.transform.position = new Vector2(0, 0);
            }
        }

        delta = Vector2.zero;
    }
}
