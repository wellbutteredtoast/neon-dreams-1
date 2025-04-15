using System;
using Raylib_cs;
using MoonSharp.Interpreter;
using System.Text.Json;

// Both items and currencies are defined in this file
// As well as the item manager system
//

namespace NeonDreams
{
    // From the base Item class all ingame item types are derived and implemented
    public enum ItemTypes
    {
        ITEM_WEAPON,
        ITEM_MATERIAL,
        ITEM_CURRENCY,
        ITEM_WEARABLE_HEAD,
        ITEM_WEARABLE_CHEST,
        ITEM_WEARABLE_LEGS,
    }

    public abstract class Item
    {

    }

    public class Weapon : Item
    {

    }

    public class Armour : Item
    {

    }

    public class Material : Item
    {

    }

    public class Coin : Item
    {

    }

    internal class ItemManager
    {

    }
}