using UnityEngine;

public struct UnitViewData
{
    [SerializeField] private ushort _id;
    [SerializeField] private int _line;
    [SerializeField] private Vector2 _position;

    public UnitViewData(ushort id, int line, Vector2 position)
    {
        _id = id;
        _line = line;
        _position = position;
    }

    public ushort ID => _id;
    public int Line => _line;
    public Vector2 Position => _position;
}