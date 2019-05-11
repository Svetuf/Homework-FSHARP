module Logic

    let rec concat a b =
        match a with
        | [] -> b
        | h::tail -> concat tail (h::b)