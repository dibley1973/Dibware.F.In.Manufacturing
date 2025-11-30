namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Operations
open Dibware.F.In.Manufacturing.Domain.Types.ProcessingPlants
open Dibware.F.In.Manufacturing.Domain.Types.Mining

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
        let actual = Smelting.getIronOreSmeltingPlant()

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(expected, actual);

