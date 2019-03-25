
let rec pow number power =
    if power = 1 then number
    else number * pow number (power - 1)

let fillList n m = 
    let rec loop n list acc =
        match n with
        | 0 -> list
        | _ -> loop (n-1) (list::(acc*2)) acc*2

    loop n (List.init (m+1) (fun i -> pow 2 i))

let a = fillList 5 5