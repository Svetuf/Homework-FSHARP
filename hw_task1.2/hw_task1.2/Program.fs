let fibonacci n = 
    let rec loop count firstNum secNum = 
        match count with
        | 0 -> secNum
        | _ -> loop (count - 1) (secNum) (firstNum + secNum)
    match n with
    | 1 -> 1
    | 2 -> 2
    | x when x > 2  -> loop n 1 1
