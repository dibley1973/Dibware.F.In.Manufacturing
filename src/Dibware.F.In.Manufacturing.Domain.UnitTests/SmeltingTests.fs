namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Plants
open Dibware.F.In.Manufacturing.Domain.Data

[<TestClass>]
type SmeltingTests () =

    [<TestMethod>]
    member this.getSmeltingPlantForOre_WithSupportedOre_ReturnsSmelter () =
        // Arrange
        let expected = SmeltingPlant.IronOreSmelter
        let ironOre = Ore.IronOre 

        // Act
        let actual = Smelting.getSmeltingPlantForOre(ironOre)

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual((expected |> Some), actual);

    [<TestMethod>]
    member this.getSmeltingPlantForOre_WithunsupportedOre_ReturnsNone () =
        // Arrange
        //let expected = SmeltingPlant.IronOreSmelter
        let ironOre = Ore.GoldOre

        // Act
        let actual = Smelting.getSmeltingPlantForOre(ironOre)

        // Assert
        Assert.IsTrue(actual.IsNone);
