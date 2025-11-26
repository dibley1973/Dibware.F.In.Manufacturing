namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Generators.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Mining

[<TestClass>]
type TerraformingTests () =

    [<TestMethod>]
    member public this.terraformRandomLand_WithValidDimensions_ReturnsGameArea () =
        // Arrange
        let length = 10
        let width = 10

        // Act
        let actual = terraformRandomLandWithDimensions length width
        
        // Assert
        Assert.IsNotNull(actual)
        Assert.AreEqual(length, actual.Map.GetLength(0))
        Assert.AreEqual(width, actual.Map.GetLength(1))

    [<TestMethod>]
    member public this.terraformBiasedLand_WithValidDimensions_ReturnsGameArea () =
        // Arrange
        let length = 10
        let width = 10

        // Act
        let actual = terraformBiasedLand(length, width, 70) Rock.IronImpregnatedRock
        
        // Assert
        Assert.IsNotNull(actual)
        Assert.AreEqual(length, actual.Map.GetLength(0))
        Assert.AreEqual(width, actual.Map.GetLength(1))

    [<TestMethod>]
    member public this.terraformBiasedLand_With70PercentPreferredRock_ReturnsGameAreaContainsAtLeast70OfPreferredRockElements () =
        // Arrange
        let length = 10
        let width = 10
        let preferredRock = Rock.IronImpregnatedRock
        let expectedFlattenedLength = length * width
        let expectedMinimumPreferredRockCount = (expectedFlattenedLength * 70) / 100

        // Act
        let landGrid = terraformBiasedLand(length, width, 70) Rock.IronImpregnatedRock
        let actual = landGrid.Grid |> Seq.cast<Rock> |> Seq.toArray
        let actualPreferredRockCount = actual |> Array.filter(fun rock -> rock = preferredRock) |> Array.length
        
        // Assert
        Assert.IsNotNull(actual)
        Assert.AreEqual(expectedFlattenedLength, actual.GetLength(0))
        Assert.IsTrue(actualPreferredRockCount >= expectedMinimumPreferredRockCount)