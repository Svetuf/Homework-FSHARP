exception WrongInputExeption of string

let factorial number = 
    let rec loop number acc = 
        match number with 
        | x when x < 0 -> raise (WrongInputExeption("the input is below zero"))
        | 0 -> 1
        | 1 -> acc
        | _ -> loop (number - 1) (acc * number)
    loop number 1
