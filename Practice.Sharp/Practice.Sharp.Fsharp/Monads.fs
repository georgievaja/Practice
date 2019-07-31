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

    let (>=>) f1 f2 arg =
        f1 arg >>= f2

    let (++) f1 f2 =
        match f1 with
        | Success s1 -> match f2 with
                        | Success s2 -> Success (s1, s2)
                        | Failure f2 -> Failure f2
        | Failure f1 -> Failure f1
    
