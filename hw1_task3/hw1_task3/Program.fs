module logic

    let rev list =
        let rec loop list acc=
            match list with
            | [] -> acc
            | head::tail -> loop tail (head::acc)
        loop list []
