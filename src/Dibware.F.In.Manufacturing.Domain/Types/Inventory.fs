namespace Dibware.F.In.Manufacturing.Domain.Types.Inventory

module DeleteMeLater =
    let x = 42
    (*
    This module is to be deleted later.
    It contains an inventory implementation that uses
    my original material type definitions, rather than
    the alternative material type definitions provided
    by Brian Berns.
    *)

///// <summary>
///// Using my original material type definitions.
///// </summary>
//module Inventory_OriginalMaterialTypes =

//open Dibware.F.In.Manufacturing.Domain.Types.Mining
//open Dibware.F.In.Manufacturing.Domain.Types.Materials

///// <summary>
///// Represents the name of an item in the inventory.
///// </summary>
//type Name = string

///// <summary>
///// Represents the quantity of a specific item in an inventory.
///// </summary>
//type Quantity = int

///// <summary>
///// Represents a type of an item in the inventory.
///// </summary>
//type InventoryItem =
//    | Rock of Rock
//    | Ore of Ore
//    | Raw of RawMaterial
//    | Processed of ProcessedMaterial
//    | ComponentItem of Component

///// <summary>
///// Represents an inventory item along with its quantity.
///// </summary>
//type InventoryItemQuantity = {
//    Name : Name
//    Item : InventoryItem
//    Quantity : Quantity
//}