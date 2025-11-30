namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
//open Dibware.F.In.Manufacturing.Domain.Types
//open Dibware.F.In.Manufacturing.Domain.Types.Mining
//open Dibware.F.In.Manufacturing.Domain.Types.Inventory
open Dibware.F.In.Manufacturing.Domain.Behaviours
open Dibware.F.In.Manufacturing.Domain.Types.Materials_Alternative_Brian

(*
These currently do not compile correctly, so I need to fix that, but I am not sure how to do so at the moment!
See note above `Inventory_Alternative_BasedUponBrians` module .
*)

/// <summary>
/// Tests for Inventory behaviour
/// </summary>
[<TestClass>]
type Inventory_Brian_Version_Tests () =
    [<TestMethod>]
    member this.createEmptyInventory_ReturnsEmptyMap () =
        // Arrange
        // Act
        let actual = Inventory.createEmptyInventory()
        
        // Assert
        Assert.AreEqual(Map.empty, actual);

    [<TestMethod>]
    member this.getItem_WithEmptyInventory_ReturnsNone () =
           // Arrange
            let itemName = "Iron Ore"
            let inventory : Inventory.T = Inventory.createEmptyInventory()
            
            // Act
            let actual = Inventory.getItem itemName inventory
            
            // Assert
            Assert.IsTrue(actual.IsNone);
            Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.getItem_WithExistingItem_ReturnsItem () =
        // Arrange
        let itemName = "Iron Ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity : Inventory.InventoryItemQuantity = {
            Name = itemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (itemName, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory.getItem itemName inventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(inventoryItemQuantity, actual.Value);

    [<TestMethod>]
    member this.getItem_WithNonExistingItem_ReturnsNone () =
        // Arrange
        let nameOfItemThatExists = "Iron Ore"
        let nameOfItemThatDoesNotExist = "Gold Ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = nameOfItemThatExists
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (nameOfItemThatExists, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory.getItem nameOfItemThatDoesNotExist inventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.getItem_WithDifferentCasedItemName_ReturnsNone () =
        // Arrange
        let itemNameInInventory = "Iron Ore"
        let itemNameToRetrieve = "iron ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = itemNameInInventory
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (itemNameInInventory, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory.getItem itemNameToRetrieve inventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.getItem_WithLeadingTrailingSpacesInItemName_ReturnsNone () =
        // Arrange
        let itemNameInInventory = "Iron Ore"
        let itemNameToRetrieve = "  Iron Ore  "
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = itemNameInInventory
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (itemNameInInventory, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory.getItem itemNameToRetrieve inventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.removeItem_WithExistingItem_RemovesItem () =
        // Arrange
        let itemName = "Iron Ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (itemName, inventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = inventory |> Map.remove itemName
        let actual = Inventory.getItem itemName updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);
        Assert.AreEqual(0, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.removeItem_WithNonExistingItem_InventoryUnchanged () =
        // Arrange
        let existingItemName = "Iron Ore"
        let nonExistingItemName = "Gold Ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = existingItemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (existingItemName, inventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = inventory |> Map.remove nonExistingItemName
        let actual = Inventory.getItem existingItemName updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(inventoryItemQuantity, actual.Value);
        Assert.AreEqual(1, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.removeItem_FromEmptyInventory_InventoryRemainsEmpty () =
        // Arrange
        let nonExistingItemName = "Gold Ore"
        let inventory : Inventory.T = Inventory.createEmptyInventory()
        
        // Act
        let updatedInventory = inventory |> Map.remove nonExistingItemName
        let actual = Inventory.getItem nonExistingItemName updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);
        Assert.AreEqual(0, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.removeItem_WithDifferentCasedItemName_InventoryUnchanged () =
        // Arrange
        let itemNameInInventory = "Iron Ore"
        let itemNameToRemove = "iron ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = itemNameInInventory
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (itemNameInInventory, inventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = inventory |> Map.remove itemNameToRemove
        let actual = Inventory.getItem itemNameInInventory updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(inventoryItemQuantity, actual.Value);
        Assert.AreEqual(1, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.addOrUpdateItem_WithNewItem_AddsItem () =
        // Arrange
        let itemName = "Iron Ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantityToAdd  : Inventory.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T = Inventory.createEmptyInventory()
        
        // Act
        let updatedInventory = Inventory.addOrUpdateItem inventoryItemQuantityToAdd inventory
        let actual = Inventory.getItem itemName updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(inventoryItemQuantityToAdd, actual.Value);
        Assert.AreEqual(1, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.addOrUpdateItem_WithExistingItem_UpdatesItem () =
        // Arrange
        let itemName = "Iron Ore"
        let originalQuantity = 10
        let newQuantity = 20
        let expectedQuantity = originalQuantity + newQuantity
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let initialInventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = originalQuantity
        }
        let updatedInventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = newQuantity
        }
        let inventory : Inventory.T =
            Map.ofList [
                (itemName, initialInventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = Inventory.addOrUpdateItem updatedInventoryItemQuantity inventory
        let actual = Inventory.getItem itemName updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(itemName, actual.Value.Name);
        Assert.AreEqual(expectedQuantity, actual.Value.Quantity);
        Assert.AreEqual(1, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.checkStockLevel_WithExistingItem_ReturnsQuantity () =
        // Arrange
        let itemName = "Iron Ore"
        let expectedQuantity = 15
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = expectedQuantity
        }
        let inventory : Inventory.T =
            Map.ofList [
                (itemName, inventoryItemQuantity)
            ]
        
        // Act
        let actualQuantity = Inventory.checkStockLevel itemName inventory
        
        // Assert
        Assert.AreEqual(expectedQuantity, actualQuantity);

    [<TestMethod>]
    member this.checkStockLevel_WithNonExistingItem_ReturnsZero () =
        // Arrange
        let existingItemName = "Iron Ore"
        let nonExistingItemName = "Gold Ore"
        let ore = Ore.IronOre
        let oreItem = Raw (RawOre ore)
        let inventoryItemQuantity  : Inventory.InventoryItemQuantity= {
            Name = existingItemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory.T =
            Map.ofList [
                (existingItemName, inventoryItemQuantity)
            ]
            
        // Act
        let actualQuantity = Inventory.checkStockLevel nonExistingItemName inventory
            
        // Assert
        Assert.AreEqual(0, actualQuantity);