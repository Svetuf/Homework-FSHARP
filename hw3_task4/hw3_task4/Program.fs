module Logic

    /// Function that return true if number is prime
    /// returns false if it's not.
    let isPrime number =
        match number with
        | x when x < 2 -> false
        | 2 -> true
        | _ -> let rec checkForPrime i =
                   if i > (int (sqrt (float number)) + 1) then true
                   else
                       match (number % i) with
                       | 0 -> false
                       | _ -> checkForPrime (i + 1)
               checkForPrime 2

    /// Function that make an infinite sequenxe of prime numbers
    let infinitPrimes () =
        Seq.initInfinite (fun i -> i) |> Seq.filter(isPrime) 

    do infinitPrimes() |> ignore