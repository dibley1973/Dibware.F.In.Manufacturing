namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Generators.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Mining

[<TestClass>]
type TerraformingTests =

    [<TestMethod>]
    member public this.terraformRandomLand_WithValidDimensions_ReturnsGameArea () =
        // Arrange
        let length = 10
        let width = 10

        // Act
        let actual = terraformRandomLand(length, width)
        
        // Assert
        Assert.IsNotNull(actual)
        Assert.AreEqual(length, actual.Grid.GetLength(0))
        Assert.AreEqual(width, actual.Grid.GetLength(1))

    [<TestMethod>]
    member public this.terraformBiasedLand_WithValidDimensions_ReturnsGameArea () =
        // Arrange
        let length = 10
        let width = 10

        // Act
        let actual = terraformBiasedLand(length, width, 70) Rock.IronImpregnatedRock
        
        // Assert
        Assert.IsNotNull(actual)
        Assert.AreEqual(length, actual.Grid.GetLength(0))
        Assert.AreEqual(width, actual.Grid.GetLength(1))
