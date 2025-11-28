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

    [<TestMethod>]
    member this.getItem_WithDifferentCasedItemName_ReturnsNone () =
        // Arrange
        let itemNameInInventory = "Iron Ore"
        let itemNameToRetrieve = "iron ore"
        let oreItem = Ore(Ore.IronOre, 10)
        let inventoryItemQuantity = {
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
        let oreItem = Ore(Ore.IronOre, 10)
        let inventoryItemQuantity = {
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
        let updatedInventory = inventory |> Map.remove itemName
        let actual = Inventory.getItem itemName updatedInventory
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);
        Assert.AreEqual(0, Map.count updatedInventory);