namespace Dibware.F.In.Manufacturing.Domain.Types

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
type InventoryItem =
    | Rock of Rock * Quantity
    | Ore of Ore * Quantity
    | Raw of RawMaterial * Quantity
    | Processed of ProcessedMaterial * Quantity
    | ComponentItem of Component * Quantity

/// <summary>
/// Represents an inventory item along with its quantity.
/// </summary>
type InventoryItemQuantity = {
    Name : Name
    Item : InventoryItem
    Quantity : Quantity
}

/// <summary>
/// Represents an inventory containing various items.
/// </summary>
module Inventory =

    // The Inventory type is a map where the key is the item name (string)
    // and the value is the InventoryItem record.
    type T = Map<string, InventoryItemQuantity>

    ///// <summary>
    ///// Represents an empty inventory
    ///// </summary>
    //let empty : T = Map.empty

    /// <summary>
    /// Creates an empty inventory.
    /// </summary>
    let createEmptyInventory() : T =  
        Map.empty

        // Function to get an item (returns an Option<InventoryItem>)
    let getItem name (inventory: T) : Option<InventoryItemQuantity> =
        Map.tryFind name inventory
        
    // Function to remove an item
    let removeItem name (inventory: T) : T =
        Map.remove name inventory

    /// <summary>
    /// Adds a new entry into the specified inventory, or updates 
    /// the quantity of an existing item.
    /// </summary>
    let addOrUpdateItem (item: InventoryItemQuantity) (inventory: T) : T =
        let itemExists = Map.containsKey item.Name inventory
        if (itemExists) then
            // Update existing entry
            let existingItem = Map.find item.Name inventory
            let updatedQuantity = existingItem.Quantity + item.Quantity
            let updatedItem = { existingItem with Quantity = updatedQuantity }
            let updatedInventory = removeItem item.Name inventory
            let resultInventory = Map.add item.Name updatedItem updatedInventory
            resultInventory
        else
            // Add new entry
            let resultInventory = Map.add item.Name item inventory
            resultInventory



    // Example of a function to check stock level
    let checkStock name (inventory: T) : int =
        match getItem name inventory with
        | Some item -> item.Quantity
        | None -> 0