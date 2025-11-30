namespace Dibware.F.In.Manufacturing.Domain.Behaviours

open Dibware.F.In.Manufacturing.Domain.Types.Materials_Alternative_Brian

(*
Source - https://stackoverflow.com/a/79833562
Posted by Brian Berns, modified by community. See post 'Timeline' for change history
Retrieved 2025-11-30, License - CC BY-SA 4.0
*)

module Inventory_Alternative_Brian =
    let inventory =
        [
            Raw (RawOre IronOre)
            Raw (RawOil CrudeOil)
            Raw (RawGas NaturalGas)
            Refined (RefinedIngot IronIngot)
        ]

(*
I now need to try an implement Brian Berns' material types into an inventory system,
similar to what I have already done using my own material type definitions.
Below is my existing inventory system, modified to use Brian's material types.
However if you look at `Inventory_Brian_Version_Tests` they do not compile correctly,
so I need to fix that, but I am not sure how to do so at the moment!
*)

/// <summary>
/// Using structures from Brian Berns' alternative material type definitions.
/// </summary>
module  Inventory_Alternative_BasedUponBrians =
    /// <summary>
    /// Represents the name of an item in the inventory.
    /// </summary>
    type Name = string

    /// <summary>
    /// Represents the quantity of a specific item in an inventory.
    /// </summary>
    type Quantity = int

    /// <summary>
    /// Represents an inventory item along with its quantity.
    /// </summary>
    type InventoryItemQuantity = {
        Name : Name
        Item : Material
        Quantity : Quantity
    }

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