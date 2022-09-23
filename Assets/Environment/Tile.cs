using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField] Tower towerPrefab;

    [SerializeField]bool isPlaceable;

    GridManager gridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();
    void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }
    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    public bool IsPlaceable {get {return isPlaceable;}} //Gettter methode notice no parenthesis
    
    
   void OnMouseDown() 
   {
    if(gridManager.GetNode(coordinates).isWalkable && !pathFinder.willBlockPath(coordinates))
    {
        bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
    
        isPlaceable = !isPlaced;
        gridManager.BlockNode(coordinates);
    }
    
   }
    
}

