namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Operations
open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Materials

[<TestClass>]
type MiningTests () =

    [<TestMethod>]
    member this.getMiningPlantForOre_WithSupportedOre_ReturnsMine () =
        // Arrange
        let expected = (Mine.IronOreMine |> Some)
        let ironOre = Ore.IronOre 

        // Act
        let actual = Mining.getMiningPlantForOre(ironOre)

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.getMiningPlantForOre_WithunsupportedOre_ReturnsNone () =
        // Arrange
        let goldOre = Ore.GoldOre

        // Act
        let actual = Mining.getMiningPlantForOre(goldOre)

        // Assert
        Assert.IsTrue(actual.IsNone);

    [<TestMethod>]
    member this.getMiningPlantForOre_ReturnsIronOreMine () =
        // Arrange
        let expected = (Mine.IronOreMine |> Some)
        
        // Act
        let actual = Mining.getIronOreMine

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(expected, actual);
