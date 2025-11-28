namespace Dibware.F.In.Manufacturing.Domain.Types.Inventory

open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Materials

/// <summary>
/// Represents the name of an item in the inventory.
/// </summary>
type Name = string

/// <summary>
/// Represents the quantity of a specific item in an inventory.
/// </summary>
type Quantity = int

/// <summary>
/// Represents a type of an item in the inventory.
/// </summary>
type InventoryItem =
    | Rock of Rock
    | Ore of Ore
    | Raw of RawMaterial
    | Processed of ProcessedMaterial
    | ComponentItem of Component

/// <summary>
/// Represents an inventory item along with its quantity.
/// </summary>
type InventoryItemQuantity = {
    Name : Name
    Item : InventoryItem
    Quantity : Quantity
}