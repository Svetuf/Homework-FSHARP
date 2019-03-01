exception WrongInputExeption of string

let fibonacci number = 
    let rec loop count fib1 fib2 = 
        match count with
        |0 -> fib1
        |_ -> loop (count - 1) (fib1 + fib2) fib1
    match number with
    |x when x < 0 ->  raise (WrongInputExeption("Wrong number"))
    |x when x < 3 -> 1
    |_ -> loop (number - 2) 1 1


// example 
let a = fibonacci 8