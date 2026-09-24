using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string Itemname;
    [SerializeField] private Sprite icon;

    public Sprite Icon()
    {
        return icon;
    }
}
