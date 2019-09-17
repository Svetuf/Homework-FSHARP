module Logic

    open System

    // Make a calculus with numbers witch are in strings.
    type WorkFlowString () =
        member this.Bind(s: string, f) =
            match System.Int32.TryParse(s) with
            | (true, b) -> f b
            | _ -> None
        member this.Return(s) =
            Some(s)
        