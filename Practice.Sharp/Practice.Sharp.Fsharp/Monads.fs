module Monads

type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure

module Operators =

    let bind    (res: Result<'a, 'e>) 
                (f: 'a -> Result<'c, 'e>) : Result<'c, 'e> =
        match res with
        | Success(x) -> f x
        | Failure f -> Failure f

    let (>>=) = bind

    let compose (f1: 'a -> Result<'b, 'e>)
                (f2: 'b -> Result<'c, 'e>)
                (arg: 'a): Result<'c,'e> =
        match f1 arg with
        | Success s -> f2 s
        | Failure f -> Failure f

    let (>>) = compose
        
    
