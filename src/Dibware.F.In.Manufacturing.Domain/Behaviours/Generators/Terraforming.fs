namespace Dibware.F.In.Manufacturing.Domain.Behaviours.Generators

open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Measurements

module Terraforming =
    /// <summary>
    /// An array of available rock types.
    /// </summary>
    let rocks = [|
        IronImpregnatedRock; 
        CoalImpregnatedRock; 
        CopperImpregnatedRock; 
        GasShale;
        OilShale;
        Useless;
        VoidOfAnyRock;
    |]

    /// <summary>
    /// A helper function that gets a random rock type.
    /// </summary>
    /// <remarks>This function is impure due to the use of randomness.</remarks>
    let public getRandomRock () : Rock =
        let randomIndex = System.Random().Next(rocks.Length)
        
        rocks.[randomIndex]

    /// <summary>
    /// A helper function that gets a rock type with a bias towards a preferred rock type.
    /// </summary>
    /// <remarks>This function is impure due to the use of randomness.</remarks>
    let public getPreferredRockWithBias (biasPercentage: int) (preferredRock: Rock) : Rock =
        let randomValue = System.Random().Next(0, 100)
        
        if randomValue < biasPercentage then
            preferredRock
        else
            getRandomRock()

    /// <summary>
    /// A factory function that terraforms a 2D world using the provided rock map.
    /// </summary>
    /// <param name="map">The 2D rock map to use in terraforming the world.</param>
    /// <returns>
    /// A <see cref="World2D" /> representing the terraformed 2D world.
    /// </returns>
    let public terraform2DWorldFromMap (map: Rock[,]) : World2D =

        // Read the world size from the map
        let size2D = { 
            X = map.GetLength(0)
            Y = map.GetLength(1)
        }

        // Generated and return the world in 2D
        { Dimensions = size2D; Map = map } : World2D

    /// <summary>
    /// A factory function that terraforms a 2D world using the provided size and rock generator function.
    /// </summary>
    /// <param name="size">The 2D size of the world to create.</param>
    /// <param name="rockGenerator">
    /// A function that generates a rock type based on the provided X and Y coordinates.
    /// </param>
    /// <returns>
    /// A <see cref="World2D" /> representing the terraformed 2D world.
    /// </returns>
    let public terraform2DWorldFromSizeAndGenerator (size: Size2D, rockGenerator ) : World2D =
        let map2D = Array2D.init size.X size.Y rockGenerator
        let world2D =terraform2DWorldFromMap(map2D)

        world2D

    /// <summary>
    /// A factory function that terraforms a 2D world with random rock formations. 
    /// Uses the <see cref="getRandomRock" /> function to totally random.rock type selection.
    /// </summary>
    /// <param name="size">The 2D size of the world to create.</param>
    /// <returns>
    /// A <see cref="World2D" /> representing the terraformed 2D world.
    /// </returns>
    let public terraformRandom2DWorldWithSize (size: Size2D) : World2D = 

        let rockGenerator = fun _ _ -> getRandomRock()

        terraform2DWorldFromSizeAndGenerator(size, rockGenerator)

    /// <summary>
    /// A factory function that terraforms a world with a bias towards a preferred rock type. 
    /// The higher the biasPercentage,the more likely the preferred rock type will appear.
    /// </summary>
    /// <param name="size">The 2D size of the world to create.</param>
    /// <param name="biasPercentage">An integer representing the percentage chance of the preferred rock type appearing.</param>
    /// <param name="preferredRock">The preferred rock type to bias towards.</param>
    /// <returns>
    /// A <see cref="World2D" /> representing the terraformed 2D world.
    /// </returns>
    let public terraformPreferredRock2DWorldWithSize (size: Size2D) (biasPercentage: int) (preferredRock: Rock) : World2D =

        let rockGenerator = fun _ _ -> getPreferredRockWithBias biasPercentage preferredRock

        terraform2DWorldFromSizeAndGenerator( size, rockGenerator )
