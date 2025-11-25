namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Operations
open Dibware.F.In.Manufacturing.Domain.Data

[<TestClass>]
type SmeltingTests () =

    [<TestMethod>]
    member this.getSmeltingPlantForOre_WithSupportedOre_ReturnsSmelter () =
        // Arrange
        let expected = (SmeltingPlant.IronOreSmelter|> Some)
        let ironOre = Ore.IronOre 

        // Act
        let actual = Smelting.getSmeltingPlantForOre(ironOre)

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.getSmeltingPlantForOre_WithunsupportedOre_ReturnsNone () =
        // Arrange
        let goldOre = Ore.GoldOre

        // Act
        let actual = Smelting.getSmeltingPlantForOre(goldOre)

        // Assert
        Assert.IsTrue(actual.IsNone);

    [<TestMethod>]
    member this.getSmeltingPlantForIronOre_ReturnsIronOreSmelter () =
        // Arrange
        let expected = (SmeltingPlant.IronOreSmelter |> Some)
        
        // Act
        let actual = Smelting.ironOreSmeltingPlant

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(expected, actual);

