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

/// <summary>
/// Represents an inventory containing various items.
/// </summary>
module Inventory =

    /// <summary>
    /// The Inventory type is a map where the key is the item name (string)
    /// and the value is the InventoryItem record.
    /// </summary>
    type T = Map<string, InventoryItemQuantity>

    /// <summary>
    /// Creates an empty inventory.
    /// </summary>
    /// <returns>An empty inventory of type T.</returns>
    let createEmptyInventory() : T =  
        Map.empty

    /// <summary>
    /// Function to get an item (returns an Option<InventoryItem>)
    /// </summary>
    /// <param name="name">The name of the item to retrieve.</param>
    /// <param name="inventory">The inventory from which to retrieve the item.</param>
    /// <returns>An Option containing the InventoryItem if found, otherwise None.</returns>
    let getItem name (inventory: T) : Option<InventoryItemQuantity> =
        Map.tryFind name inventory
    
    /// <summary>
    /// Function to remove an item
    /// </summary>
    /// <param name="name">The name of the item to remove.</param>
    /// <param name="inventory">The inventory from which to remove the item.</param>
    /// <returns>The updated inventory after removing the item.</returns>
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