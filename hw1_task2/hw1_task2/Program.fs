module Logic

    exception WrongInputError of string

    let fibonacci n = 
        let rec loop count firstNumber secondNumber = 
            match count with
            | 0 -> secondNumber
            | _ -> loop (count - 1) (secondNumber) (firstNumber + secondNumber)
        match n with
        | 0 -> 0
        | 1 -> 1
        | 2 -> 2
        | x when x > 2  -> loop (n - 2) 1 1
        | _ -> raise (WrongInputError("The given number is below zero."))