module Logic

    let rec concat list1 list2 =
        match list1 with
        | [] -> list2
        | h::tail -> concat tail (h::list2)