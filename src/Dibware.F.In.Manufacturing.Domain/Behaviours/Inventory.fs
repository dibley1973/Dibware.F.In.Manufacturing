namespace Dibware.F.In.Manufacturing.Domain.Behaviours

open Dibware.F.In.Manufacturing.Domain.Types.Inventory

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
        
        if (itemExists) then // Update existing entry
            let existingItem = Map.find item.Name inventory
            let updatedQuantity = existingItem.Quantity + item.Quantity
            let updatedItem = { existingItem with Quantity = updatedQuantity }
            let updatedInventory = removeItem item.Name inventory
            let resultInventory = Map.add item.Name updatedItem updatedInventory
            resultInventory

        else // Add new entry
            let resultInventory = Map.add item.Name item inventory
            resultInventory

    /// <summary>
    /// Checks the stock level of an inventory item by name.
    /// </summary>
    /// <param name="name">The name of the item to check.</param>
    /// <param name="inventory">The inventory to check.</param>
    /// <returns>The quantity of the item in stock, or 0 if not found.</returns>
    let checkStockLevel name (inventory: T) : int =
        match getItem name inventory with
        | Some item -> item.Quantity
        | None -> 0