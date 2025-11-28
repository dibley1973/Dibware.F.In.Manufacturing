namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Operations
open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Measurements

/// <summary>
/// Tests for Mining behaviour
/// </summary>
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

    [<TestMethod>]
    member this.mineLocation_WithUselessRock_ReturnsNone () =
        // Arrange
        let location : Coordinate2D = { XPosition = 0; YPosition = 0}
        let rockMap = Array2D.create 1 1 Rock.Useless
        let worldSize : Size2D = { XLength = 1; YLength = 1 }
        let world : World2D = { Dimensions = worldSize; Map = rockMap }
        let rockMiner (loc: Coordinate2D, w: World2D) : Rock =
            w.Map.[loc.XPosition, loc.YPosition]
        
        // Act
        let actual = Mining.mineLocation(location, world, rockMiner)
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.mineLocation_WithVoidOfAnyRock_ReturnsNone () =
        // Arrange
        let location : Coordinate2D = { XPosition = 0; YPosition = 0}
        let rockMap = Array2D.create 1 1 Rock.VoidOfAnyRock
        let worldSize : Size2D = { XLength = 1; YLength = 1 }
        let world : World2D = { Dimensions = worldSize; Map = rockMap }
        let rockMiner (loc: Coordinate2D, w: World2D) : Rock =
            w.Map.[loc.XPosition, loc.YPosition]
        
        // Act
        let actual = Mining.mineLocation(location, world, rockMiner)
        
        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(None, actual);

    [<TestMethod>]
    member this.mineLocation_WithIronImpregnatedRock_ReturnsSomeIronOre () =
        // Arrange
        let location : Coordinate2D = { XPosition = 0; YPosition = 0}
        let rockMap = Array2D.create 1 1 Rock.IronImpregnatedRock
        let worldSize : Size2D = { XLength = 1; YLength = 1 }
        let world : World2D = { Dimensions = worldSize; Map = rockMap }
        let rockMiner (loc: Coordinate2D, w: World2D) : Rock =
            w.Map.[loc.XPosition, loc.YPosition]
        
        // Act
        let actual = Mining.mineLocation(location, world, rockMiner)
        
        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(Rock.IronImpregnatedRock, actual.Value);
