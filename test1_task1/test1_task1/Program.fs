module Logic

    /// A main function which applies the multivalued
    /// function f to the list and returns a list of values.
    let supermap list f =
        let rec loop list f acc =
            match list with
            | [] -> acc
            | [a] -> loop [] f (acc @ (f a))
            | h::tail -> loop tail f (acc @ (f h))
        loop list f []