namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Generators.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Measurements

[<TestClass>]
type TerraformingTests () =

    [<TestMethod>]
    member public this.terraformRandom2DWorldWithSize_WithValidDimensions_ReturnsGameArea () =
        // Arrange
        let xLength = 10
        let yLength = 12
        let size: Size2D = { X = xLength; Y = yLength }
        let arrayDimensionForX = 0
        let arrayDimensionForY = 1

        // Act
        let actual = terraformRandom2DWorldWithSize size
        
        // Assert
        Assert.IsNotNull(actual)
        Assert.AreEqual(xLength, actual.Map.GetLength(arrayDimensionForX))
        Assert.AreEqual(yLength, actual.Map.GetLength(arrayDimensionForY))

    [<TestMethod>]
    member public this.terraformFixedRock2DWorldWithSize_WithValidDimensions_ReturnsGameArea () =
        // Arrange
        let xLength = 10
        let yLength = 12
        let size: Size2D = { X = xLength; Y = yLength }
        let arrayDimensionForX = 0
        let arrayDimensionForY = 1

        // Act
        let actual = terraformFixedRock2DWorldWithSize(size) Rock.IronImpregnatedRock
        
        // Assert
        Assert.IsNotNull(actual)
        Assert.AreEqual(xLength, actual.Map.GetLength(arrayDimensionForX))
        Assert.AreEqual(yLength, actual.Map.GetLength(arrayDimensionForY))

    //[<TestMethod>]
    //member public this.terraformPreferredRock2DWorldWithSize_With70PercentPreferredRock_ReturnsGameAreaContainsAtLeast70OfPreferredRockElements () =
    //    // Arrange
    //    let xLength = 10
    //    let yLength = 12
    //    let size: Size2D = { X = xLength; Y = yLength } 
    //    let preferredRock = Rock.IronImpregnatedRock
    //    let expectedFlattenedLength = xLength * yLength
    //    let expectedMinimumPreferredRockCount = (expectedFlattenedLength * 70) / 100

    //    // Act
    //    let actual = terraformPreferredRock2DWorldWithSize size 70 preferredRock
    //    let flatten (map: Rock[,]) : Rock[] =
    //        [|
    //            for x in 0 .. (map.GetLength(0) - 1) do
    //                for y in 0 .. (map.GetLength(1) - 1) do
    //                    yield map.[x,y]
    //        |]
    //    let seq2d = actual.Map |> Seq.fold Seq.append Seq.empty<Rock>
    //    let actualPreferredRockCount = actual |> Array.filter(fun rock -> rock = preferredRock) |> Array.length
        
    //    // Assert
    //    Assert.IsNotNull(actual)
    //    Assert.AreEqual(expectedFlattenedLength,actual.Map|> Array.collect flatten)
    //    Assert.IsTrue(actualPreferredRockCount >= expectedMinimumPreferredRockCount)