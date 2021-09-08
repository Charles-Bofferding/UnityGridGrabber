using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Represents a single Grid position
 * */
public class MapGridObject {

    public enum Type {
        Empty,
        Player,
        Anchor,
        Ambient,
        Explosive
    }

    //Set up your location on the grid
    private Grid<MapGridObject> grid;
    private int x;
    private int y;

    // This tiles relationship to the anchor point for it's shape
    private Type type;
    private int anchorDeltaX;
    private int anchorDeltaY;

    // The list of tiles attached to an anchor tile
    public List<MapGridObject> children;


    public MapGridObject(Grid<MapGridObject> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
        type = Type.Empty;
        isRevealed = false;
    }

    public int GetX() => x;
    public int GetY() => y;

    public Type GetGridType() {
        return type;
    }

    public void SetGridType(Type type) {
        this.type = type;
    }

    public void SetFlagged() {
        isFlagged = true;
        grid.TriggerGridObjectChanged(x, y);
    }

    public bool IsFlagged() {
        return isFlagged;
    }

    public void Reveal() {
        isRevealed = true;
        grid.TriggerGridObjectChanged(x, y);
    }

    public bool IsRevealed() {
        return isRevealed;
    }

    public override string ToString() {
        return type.ToString();
    }

}
