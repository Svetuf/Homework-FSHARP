module Logic

    open System
    open MathNet.Numerics.LinearAlgebra

    // Operating system class. Сontains the OS name and the probability of infection for this OS.
    type OS = {name: string; probability: float} with
        static member Create name prob = {name = name; probability = prob}

    // Class of computer. Contains the OS type and the infection flag.
    type Comp = {os: OS; mutable infected:bool} with
        static member Create os inf  = {os = os; infected = inf}

        // Variable for generating random variables.
        static member rnd = new Random()
        
        // Discrete time step. Determines whether this computer will be infected after this step.
        member this.Tick = 
            match this.infected with
                | true -> true
                | false -> (Comp.rnd.NextDouble() <= this.os.probability)
        
        // Function to infect this computer.
        member this.infect =
            this.infected <- true

        // Infected status.
        member this.status =
            this.infected

    // Network description class. Contains a list of all computers and an adjacency matrix.
    type Network = {mutable computers: list<Comp>; matrix: Matrix<double>} with
        static member Create computers matrix = {computers = computers; matrix = matrix}

        // Discrete time step. Makes calculations to infect computers.
        // At the end of the step, the infect() method is called for all infected computers.
        member this.Tick =
            let mutable infectedOnThisTurn = []
            for i in 0 .. this.computers.Length - 1 do
                if this.computers.Item(i).status then 
                    for j in 0 .. this.matrix.ColumnCount - 1 do
                        if this.matrix.Item(i,j) > 0.0 then
                            if (this.computers.Item j).Tick then infectedOnThisTurn <- this.computers.Item(j)::infectedOnThisTurn
            List.iter (fun (comp:Comp) -> comp.infect) infectedOnThisTurn

        // Current infection status of network.
        member this.status =
            List.map (fun (comp:Comp)  -> comp.status) this.computers
