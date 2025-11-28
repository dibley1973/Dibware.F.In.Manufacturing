namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Types
open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Tests for Inventory behaviour
/// </summary>
[<TestClass>]
type InventoryTests () =

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
        let oreItem = Ore(Ore.IronOre, 10)
        let inventoryItemQuantity = {
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
        let oreItem = Ore(Ore.IronOre, 10)
        let inventoryItemQuantity = {
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