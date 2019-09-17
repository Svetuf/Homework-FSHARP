﻿module Logic

    open System

    // Workflow that makes a calculus with accuracy of epsilon.
    type RoundFlow(epsilon: int) =
        member this.Bind(x: float, f) =
            f (Math.Round(x, epsilon))
        member this.Return(x: float) =
            Math.Round(x, epsilon)