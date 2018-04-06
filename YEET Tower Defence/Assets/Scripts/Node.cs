using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    BuildManager buildManager;


    public GameObject currentTurret;
    private Renderer rend;
    private Color nodeStartColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        nodeStartColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (currentTurret != null)
        {
            return;
        }
        if (TurnManager.GetPlayerWithTurn() != null)
        {
            buildManager.BuildTurretOn(this);
            return;
        }
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //When player moves game behind the UI, hovering on nodes will be disabled.
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        if (currentTurret != null)
        {
            rend.material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = nodeStartColor;
    }

}
