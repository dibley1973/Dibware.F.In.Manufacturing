namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Operations
open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Measurements

[<TestClass>]
type MiningTests () =
    [<TestMethod>]
    member this.getRockAtLocation_WithRockPresent_ReturnsRock () =
        // Arrange
        let location : Coordinate2D = { XPosition = 0; YPosition = 0}
        let rockMap = Array2D.create 1 1 Rock.IronImpregnatedRock
        let worldSize : Size2D = { XLength = 1; YLength = 1 }
        let world : World2D = { Dimensions = worldSize; Map = rockMap }

        // Act
        let actual = Mining.getRockAtLocation(location, world)

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(Rock.IronImpregnatedRock, actual.Value);

    [<TestMethod>]
    member this.getRockAtLocation_WithNoRockPresent_ReturnsNone () =
        // Arrange
        let location : Coordinate2D = { XPosition = 0; YPosition = 0}
        let rockMap = Array2D.create 1 1 Rock.VoidOfAnyRock
        let worldSize : Size2D = { XLength = 1; YLength = 1 }
        let world : World2D = { Dimensions = worldSize; Map = rockMap }

        // Act
        let actual = Mining.getRockAtLocation(location, world)

        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);



    //[<TestMethod>]
    //member this.MineLocation_WithunsupportedOre_ReturnsNone () =
    //    // Arrange
    //    let goldOre = Ore.GoldOre

    //    // Act
    //    let actual = Mining.MineLocation(goldOre)

    //    // Assert
    //    Assert.IsTrue(actual.IsNone);

    //[<TestMethod>]
    //member this.getMiningPlantForOre_ReturnsIronOreMine () =
    //    // Arrange
    //    let expected = (Mine.IronOreMine |> Some)
        
    //    // Act
    //    let actual = Mining.getIronOreMine()

    //    // Assert
    //    Assert.IsTrue(actual.IsSome);
    //    Assert.AreEqual(expected, actual);
