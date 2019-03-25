module logic

    exception WrongInputError of string

    let fibonacci n = 
        let rec loop count firstNum secNum = 
            match count with
            | 0 -> secNum
            | _ -> loop (count - 1) (secNum) (firstNum + secNum)
        match n with
        | 0 -> 0
        | 1 -> 1
        | 2 -> 2
        | x when x > 2  -> loop (n - 2) 1 1
        | x when x < 1 -> raise (WrongInputError("The given number is below zero."))

    let index = 18
    let result = fibonacci index