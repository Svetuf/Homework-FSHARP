module Logic

open System.Threading

    /// A class of parking, its about parking condition.
    type parking () =
        /// Maximum places on this parking
        let mutable max_places = 50

        let mutable free_places = max_places

        /// How much is free now.
        member this.free_places_count = free_places

        /// What we do if car is go out of parking.
        member this.car_drive_off =
            free_places <- Interlocked.Increment(ref this.free_places_count)
            true

        /// What we do if car is go in parking.
        member this.car_drive_in =
            if Interlocked.CompareExchange(ref free_places, 0, 0) > 0 then 
                free_places <- Interlocked.Decrement(ref this.free_places_count)
                true
            else false

    /// A type of entry, there would be 3 pieces.
    type entry (p : parking) =
        /// REturn "OK" is car can drive in.
        member this.car_in = 
            if p.car_drive_in = true then "OK"
            else "No place!"
        
        member this.car_out = p.car_drive_off

        


