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
        let actual = Inventory_Alternative_BasedUponBrians.createEmptyInventory()
        
        // Assert
        Assert.AreEqual(Map.empty, actual);

    [<TestMethod>]
    member this.getItem_WithEmptyInventory_ReturnsNone () =
           // Arrange
            let itemName = "Iron Ore"
            let inventory : Inventory_Alternative_BasedUponBrians.T = Inventory_Alternative_BasedUponBrians.createEmptyInventory()
            
            // Act
            let actual = Inventory_Alternative_BasedUponBrians.getItem itemName inventory
            
            // Assert
            Assert.IsTrue(actual.IsNone);
            Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.getItem_WithExistingItem_ReturnsItem () =
        // Arrange
        let itemName = "Iron Ore"
        let oreItem = Ore.IronOre
        let inventoryItemQuantity : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity = {
            Name = itemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (itemName, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory_Alternative_BasedUponBrians.getItem itemName inventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(inventoryItemQuantity, actual.Value);

    [<TestMethod>]
    member this.getItem_WithNonExistingItem_ReturnsNone () =
        // Arrange
        let nameOfItemThatExists = "Iron Ore"
        let nameOfItemThatDoesNotExist = "Gold Ore"
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = nameOfItemThatExists
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (nameOfItemThatExists, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory_Alternative_BasedUponBrians.getItem nameOfItemThatDoesNotExist inventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.getItem_WithDifferentCasedItemName_ReturnsNone () =
        // Arrange
        let itemNameInInventory = "Iron Ore"
        let itemNameToRetrieve = "iron ore"
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemNameInInventory
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (itemNameInInventory, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory_Alternative_BasedUponBrians.getItem itemNameToRetrieve inventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.getItem_WithLeadingTrailingSpacesInItemName_ReturnsNone () =
        // Arrange
        let itemNameInInventory = "Iron Ore"
        let itemNameToRetrieve = "  Iron Ore  "
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemNameInInventory
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (itemNameInInventory, inventoryItemQuantity)
            ]
        
        // Act
        let actual = Inventory_Alternative_BasedUponBrians.getItem itemNameToRetrieve inventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.removeItem_WithExistingItem_RemovesItem () =
        // Arrange
        let itemName = "Iron Ore"
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (itemName, inventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = inventory |> Map.remove itemName
        let actual = Inventory_Alternative_BasedUponBrians.getItem itemName updatedInventory
        
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
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = existingItemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (existingItemName, inventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = inventory |> Map.remove nonExistingItemName
        let actual = Inventory_Alternative_BasedUponBrians.getItem existingItemName updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(inventoryItemQuantity, actual.Value);
        Assert.AreEqual(1, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.removeItem_FromEmptyInventory_InventoryRemainsEmpty () =
        // Arrange
        let nonExistingItemName = "Gold Ore"
        let inventory : Inventory_Alternative_BasedUponBrians.T = Inventory_Alternative_BasedUponBrians.createEmptyInventory()
        
        // Act
        let updatedInventory = inventory |> Map.remove nonExistingItemName
        let actual = Inventory_Alternative_BasedUponBrians.getItem nonExistingItemName updatedInventory
        
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
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemNameInInventory
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (itemNameInInventory, inventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = inventory |> Map.remove itemNameToRemove
        let actual = Inventory_Alternative_BasedUponBrians.getItem itemNameInInventory updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(inventoryItemQuantity, actual.Value);
        Assert.AreEqual(1, Map.count updatedInventory);
        Assert.AreNotSame(inventory, updatedInventory);

    [<TestMethod>]
    member this.addOrUpdateItem_WithNewItem_AddsItem () =
        // Arrange
        let itemName = "Iron Ore"
        let oreItem = Ore.IronOre
        let inventoryItemQuantityToAdd  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T = Inventory_Alternative_BasedUponBrians.createEmptyInventory()
        
        // Act
        let updatedInventory = Inventory_Alternative_BasedUponBrians.addOrUpdateItem inventoryItemQuantityToAdd inventory
        let actual = Inventory_Alternative_BasedUponBrians.getItem itemName updatedInventory
        
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
        let oreItem = Ore.IronOre
        let initialInventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = originalQuantity
        }
        let updatedInventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = newQuantity
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (itemName, initialInventoryItemQuantity)
            ]
        
        // Act
        let updatedInventory = Inventory_Alternative_BasedUponBrians.addOrUpdateItem updatedInventoryItemQuantity inventory
        let actual = Inventory_Alternative_BasedUponBrians.getItem itemName updatedInventory
        
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
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = itemName
            Item = oreItem
            Quantity = expectedQuantity
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (itemName, inventoryItemQuantity)
            ]
        
        // Act
        let actualQuantity = Inventory_Alternative_BasedUponBrians.checkStockLevel itemName inventory
        
        // Assert
        Assert.AreEqual(expectedQuantity, actualQuantity);

    [<TestMethod>]
    member this.checkStockLevel_WithNonExistingItem_ReturnsZero () =
        // Arrange
        let existingItemName = "Iron Ore"
        let nonExistingItemName = "Gold Ore"
        let oreItem = Ore.IronOre
        let inventoryItemQuantity  : Inventory_Alternative_BasedUponBrians.InventoryItemQuantity= {
            Name = existingItemName
            Item = oreItem
            Quantity = 10
        }
        let inventory : Inventory_Alternative_BasedUponBrians.T =
            Map.ofList [
                (existingItemName, inventoryItemQuantity)
            ]
            
        // Act
        let actualQuantity = Inventory_Alternative_BasedUponBrians.checkStockLevel nonExistingItemName inventory
            
        // Assert
        Assert.AreEqual(0, actualQuantity);