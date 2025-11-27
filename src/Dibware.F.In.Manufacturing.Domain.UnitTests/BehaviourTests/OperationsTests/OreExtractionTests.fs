namespace Dibware.F.In.Manufacturing.Domain.UnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Dibware.F.In.Manufacturing.Domain.Behaviours.Operations
open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Tests for the Ore Extraction operations.
/// </summary>
[<TestClass>]
type  OreExtractionTests ()=
    [<TestMethod>]
    member this.ExtractOre_WithSupportedRock_ReturnsSomeIronOre() =
        // Arrange
        let expected = (Ore.IronOre |> Some)
        let rock = Rock.IronImpregnatedRock

        // Act
        let actual = OreExtraction.ExtractOre(rock)

        // Assert
        Assert.IsTrue(actual.IsSome);
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.ExtractOre_WithUselessRock_ReturnsNone() =
        // Arrange
        let expected = None
        let rock = Rock.Useless

        // Act
        let actual = OreExtraction.ExtractOre(rock)

        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.ExtractOre_WithVoidOfRock_ReturnsNone() =
        // Arrange
        let expected = None
        let rock = Rock.VoidOfAnyRock

        // Act
        let actual = OreExtraction.ExtractOre(rock)

        // Assert
        Assert.IsTrue(actual.IsNone);
        Assert.AreEqual(expected, actual);
