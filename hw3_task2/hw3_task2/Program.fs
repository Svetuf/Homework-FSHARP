module Logic

    type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Empty

    let rec mapForTree f (tree : Tree<'a>) =
        match tree with
        | Empty -> tree
        | Tree (a, l, r) -> 
            Tree(f a, (mapForTree f l), (mapForTree f r))

    